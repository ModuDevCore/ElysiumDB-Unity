using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;

using Mono.Data.Sqlite;

namespace ModuDevCore.ElysiumDB 
{
	using Extension;
	using Core.Settings;
	using Internal.Data;
	using Internal;

    public class ElysiumDatabase : IDisposable
    {
        public static ElysiumDatabase Instance;

        public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();

        public static ElysiumDBSettings Settings =>
            Resources.Load<ElysiumDBSettings>("ElysiumDB Settings");

        public static bool IsOffline => Application.internetReachability == NetworkReachability.NotReachable;

        public static string PlatformDataPath =>
            Application.platform == RuntimePlatform.Android
                ? $"/data/data/{Application.identifier}"
                : Application.persistentDataPath;

		public DBMeta this[string database]
		{
		    get => Connections[database];
		}

        private readonly Queue<(string message, LogType type, int frame)> _logQueue = new Queue<(string, LogType, int)>();
		private bool _loggingInitialized = false;

		public static void Log(string message) => Instance?.EnqueueLog(message, LogType.Log);
		public static void LogWarning(string message) => Instance?.EnqueueLog(message, LogType.Warning);
		public static void LogError(string message) => Instance?.EnqueueLog(message, LogType.Error);

		private void EnqueueLog(string message, LogType type = LogType.Log)
		{
		    if (string.IsNullOrEmpty(message)) return;

		    var entry = (message, type, Time.frameCount);
		    _logQueue.Enqueue(entry);

		    // Если ещё не запущен обработчик — запускаем
		    if (!_loggingInitialized)
		    {
		        _loggingInitialized = true;
		        UnityEngine.Application.quitting += () => _logQueue.Clear();
		    }
		}

        // ==================== Extensions ====================

		void RunExtensionsProcess(ExtensionEvent processEvent)
		{
		    if (Settings.extensions == null || Settings.extensions.Count == 0)
		        return;

		    var orderedExtensions = Settings.extensions
		        .OrderBy(ext =>
		        {
		            var attr = ext.GetType().GetCustomAttribute<ExtensionProcessOrderAttribute>();
		            return (attr?.Group ?? "Default", attr?.Order ?? 0);
		        })
		        .ThenBy(ext => Settings.extensions.IndexOf(ext)) // стабильность
		        .ToList();

		    if (processEvent == ExtensionEvent.Initialize)
		    {
		        foreach (var extension in orderedExtensions)
		        {
		            SafeProcess(extension, processEvent);
		        }
		    }
		    else if (processEvent == ExtensionEvent.Dispose)
		    {
		        for (int i = orderedExtensions.Count - 1; i >= 0; i--)
		        {
		            SafeProcess(orderedExtensions[i], processEvent);
		        }
		    }
		    else
		    {
		        foreach (var extension in orderedExtensions)
		        {
		            SafeProcess(extension, processEvent);
		        }
		    }
		}

		private void SafeProcess(DBExtensionBase extension, ExtensionEvent evt)
		{
		    try
		    {
		        extension.Process(evt, this);
		    }
		    catch (Exception e)
		    {
		        Debug.LogError($"[ElysiumDB] Error in extension {extension.GetType().Name} during {evt}: {e}");
		    }
		}

		public static T GetExtension<T>() where T : class
		    => GetExtensions<T>().FirstOrDefault();
		public static T[] GetExtensions<T>() where T : class
		    => GetExtensions(typeof(T)).Cast<T>().ToArray();

		public static bool HasExtension<T>() where T : class
		    => HasExtension(typeof(T));

		public static bool TryGetExtension<T>(out T extension) where T : class
		{
		    var result = TryGetExtension(typeof(T), out object obj);
		    extension = (T)obj;
		    return result;
		}

		public static T AddExtension<T>() where T : DBExtensionBase, new()
		    => (T)AddExtension(typeof(T));

		public static bool RemoveExtension<T>() where T : DBExtensionBase
		    => RemoveExtension(typeof(T));

		public static object GetExtension(Type type)
		{
		    if (type == null) throw new ArgumentNullException(nameof(type));

		    return GetExtensions(type).FirstOrDefault();
		}
		public static object[] GetExtensions(Type type)
		{
		    if (type == null) throw new ArgumentNullException(nameof(type));

		    var extensions = Settings.extensions.Where(e => e != null && type.IsAssignableFrom(e.GetType()))
		                                       .ToArray();

		    if (extensions.Length == 0)
		    {
		        Debug.LogWarning($"[ElysiumDB] Extensions of type {type.Name} not found.");
		    }
		    return extensions;
		}

		public static bool HasExtension(Type type)
		{
		    if (type == null) throw new ArgumentNullException(nameof(type));
		    return Settings.extensions.Any(e => e != null && type.IsAssignableFrom(e.GetType()));
		}

		public static bool TryGetExtension(Type type, out object extension)
		{
		    if (type == null) throw new ArgumentNullException(nameof(type));

		    extension = Settings.extensions.FirstOrDefault(e => e != null && type.IsAssignableFrom(e.GetType()));
		    return extension != null;
		}

		public static object AddExtension(Type type)
		{
		    if (type == null) throw new ArgumentNullException(nameof(type));
		    if (!typeof(DBExtensionBase).IsAssignableFrom(type))
		        throw new ArgumentException($"Type {type.Name} must inherit from DBExtensionBase");

		    var requiredAttributes = (RequireExtensionAttribute[])
		        type.GetCustomAttributes(typeof(RequireExtensionAttribute), true);

		    foreach (var attr in requiredAttributes)
		    {
		    	if(attr.AutoCreate)
		    		continue;
		        bool hasRequired = Settings.extensions.Any(ext =>
		            ext != null && attr.ExtensionType.IsAssignableFrom(ext.GetType()));

		        if (!hasRequired)
		        {
		            throw new InvalidOperationException(
		                $"Cannot add extension {type.Name} because it requires " +
		                $"{attr.ExtensionType.Name}, but it is not present in the extensions list.");
		        }
		    }

		    var extension = (DBExtensionBase)Activator.CreateInstance(type);

		    var defaultExtensionGroupAttribute = type.GetCustomAttribute<DefaultExtensionGroupAttribute>();
		    if (defaultExtensionGroupAttribute != null)
		    {
		        extension.extensionGroup = defaultExtensionGroupAttribute.ExtensionGroup;
		    }

		    Settings.extensions.Add(extension);

		    ElysiumDatabase context = Instance;
		    if (context != null)
		        context.SafeProcess(extension, ExtensionEvent.Initialize);

		#if UNITY_EDITOR
		    EditorUtility.SetDirty(Settings);
		#endif

		    DBLogger.LogContext("[ElysiumDB]", $"Extension added: {type.Name}", DBLogger.ContextLevel.Core);

		    ProcessRequiredExtensions();

		    return extension;
		}

		public static bool RemoveExtension(Type type)
		{
		    if (type == null) throw new ArgumentNullException(nameof(type));

		    var extension = Settings.extensions.FirstOrDefault(e => e != null && type.IsAssignableFrom(e.GetType()));

		    if (extension == null)
		    {
		        Debug.LogWarning($"[ElysiumDB] Extension {type.Name} not found.");
		        return false;
		    }

			List<Type> dependents = GetRequiresExtensions(type);

            if (dependents != null && dependents.Count > 0 && Settings.extensions.Where(ext => ext != null && ext.GetType() == type).ToArray().Length == 1)
            {
            	string dependentNames = string.Join(", ",
                            dependents.Select(t => t.Name));
		        Debug.LogError($"[ElysiumDB] Cannot Remove Extension\n" + 
                            $"This extension is required by:\n\n{dependentNames}");
		        return false;
            }

		    try
		    {
		        extension.Process(ExtensionEvent.Dispose, Instance);
		    }
		    catch (Exception e)
		    {
		        Debug.LogError($"[ElysiumDB] Error disposing extension {type.Name}: {e}");
		    }

		    Settings.extensions.Remove(extension);

		#if UNITY_EDITOR
		    UnityEditor.EditorUtility.SetDirty(Settings);
		    UnityEditor.AssetDatabase.SaveAssets();
		#endif

		    DBLogger.LogContext("[ElysiumDB]", $"Extension removed: {type.Name}", DBLogger.ContextLevel.Core);
		    return true;
		}

		public static List<Type> GetRequiresExtensions(Type extensionType)
		{
		    if (Settings.extensions == null || Settings.extensions.Count == 0)
		        return new List<Type>();

		    var result = new List<Type>();

		    foreach (var ext in Settings.extensions)
		    {
		        if (ext == null) continue;

		        Type type = ext.GetType();

		        var attributes = (RequireExtensionAttribute[])
		            type.GetCustomAttributes(typeof(RequireExtensionAttribute), true);

		        if (attributes.Any(attr => attr.ExtensionType == extensionType))
		        {
		            result.Add(type);
		        }
		    }

		    return result.ToList();
		}
		public static void ProcessRequiredExtensions()
		{
		    if (Settings.extensions == null) return;
		    
		    var currentExtensions = Settings.extensions.ToList();

		    foreach (var ext in currentExtensions)
		    {
		        if (ext == null) continue;

		        Type type = ext.GetType();
		        var attributes = (RequireExtensionAttribute[])
		            type.GetCustomAttributes(typeof(RequireExtensionAttribute), true);

		        foreach (var attribute in attributes)
		        {
		            if (!typeof(DBExtensionBase).IsAssignableFrom(attribute.ExtensionType))
		            {
		                Debug.LogError($"[ElysiumDB] {attribute.ExtensionType.Name} is not a DBExtensionBase.");
		                continue;
		            }

		            // Проверяем, есть ли уже такое расширение
		            bool exists = Settings.extensions.Any(e =>
		                e != null && e.GetType() == attribute.ExtensionType);

		            if (exists) continue;

		            if (attribute.AutoCreate)
		            {
		                try
		                {
		                    var extension = (DBExtensionBase)Activator.CreateInstance(attribute.ExtensionType);
		                    
		                    // Устанавливаем группу по умолчанию, если есть атрибут
		                    var groupAttr = attribute.ExtensionType.GetCustomAttribute<DefaultExtensionGroupAttribute>();
		                    if (groupAttr != null)
		                    {
		                        extension.extensionGroup = groupAttr.ExtensionGroup;
		                    }

		                    Settings.extensions.Add(extension);

		#if UNITY_EDITOR
		                    UnityEditor.EditorUtility.SetDirty(Settings);
		#endif

		                    Debug.Log($"[ElysiumDB] Auto created required extension: {attribute.ExtensionType.Name}");
		                }
		                catch (Exception ex)
		                {
		                    Debug.LogError($"[ElysiumDB] Failed to auto-create extension {attribute.ExtensionType.Name}: {ex.Message}");
		                }
		            }
		            else
		            {
		                Debug.LogError($"[ElysiumDB] Required extension missing: {attribute.ExtensionType.Name} (AutoCreate = false)");
		            }
		        }
		    }
		}

        public void New()
        {
            DBLogger.Log("<color=yellow>Initializing ElysiumDB...</color>", DBLogger.ContextLevel.Core);
            DBLogger.Log("<color=yellow>Initializing StreamingAssetsPath...</color>", DBLogger.ContextLevel.Core);
            foreach (var db in Connections.Values)
                try { db.Dispose(); } catch { }
            Connections.Clear();
            foreach (var path in Settings.dbPaths)
            {
                ConnectDB(path);
            }

            DBLogger.Log("<color=yellow>Extensions Processing...</color>", DBLogger.ContextLevel.Core);

            RunExtensionsProcess(ExtensionEvent.Initialize);

            Instance = this;

        }
        public void DetachDB(string path) {
            Connections[path].Dispose();
            Connections.Remove(path);
        }
        public void ConnectDB(string path) {
            string filePath = Path.Combine(Application.streamingAssetsPath, path);
            string destPath = Path.Combine(PlatformDataPath, path);

            var bytes = LoadFileBytes(filePath);
            if (bytes != null) EnsureFileExists(destPath, bytes);

            var conn = new SqliteConnection {
                ConnectionString = $"Data Source={destPath};Version=3;"
            };
            try {
                conn.Open();
                Connections[path] = new DBMeta { connection = conn };
                DBLogger.LogContext("DBLoader", $"<color=#81C784>DB loaded</color>: {path}", DBLogger.ContextLevel.DBLoader);
            } catch(Exception e) {
                DBLogger.LogContext("DBLoader", $"<color=#E57373>DB exception</color>: {conn.ConnectionString}\n{e}", DBLogger.ContextLevel.DBLoader);
            }
        }
        public void CreateSQLiteDatabase(string path) 
        	=> CreateSQLiteDatabase(path, new SqliteConnectionStringBuilder());
        public void CreateSQLiteDatabase(string path, bool platformDataPath) 
        	=> CreateSQLiteDatabase(path, new SqliteConnectionStringBuilder(), platformDataPath);
        public void CreateSQLiteDatabase(string path, string connectionString, bool platformDataPath = true) 
        	=> CreateSQLiteDatabase(path, new SqliteConnectionStringBuilder(connectionString), platformDataPath);
		public void CreateSQLiteDatabase(string path, SqliteConnectionStringBuilder userBuilder, bool platformDataPath = true)
		{
			string destPath = Path.Combine(PlatformDataPath, path);

		    string directory = Path.GetDirectoryName(destPath);
		    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
		    {
		        Directory.CreateDirectory(directory);
		    }

		    var builder = new SqliteConnectionStringBuilder(userBuilder.ToString())
		    {
		        DataSource = destPath
		    };

		    string connectionString = builder.ToString();

		    var conn = new SqliteConnection(connectionString);
            try {
                conn.Open();
                Connections[path] = new DBMeta { connection = conn };
                DBLogger.LogContext("DBLoader", $"<color=#81C784>DB loaded</color>: {path}", DBLogger.ContextLevel.DBLoader);
            } catch(Exception e) {
                DBLogger.LogContext("DBLoader", $"<color=#E57373>DB exception</color>: {conn.ConnectionString}\n{e}", DBLogger.ContextLevel.DBLoader);
            }
		}
        #region File Utils

        private static byte[] LoadFileBytes(string path)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                using var req = UnityWebRequest.Get(path);
                req.SendWebRequest();
                while (!req.isDone) { }
                if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError)
                    return null;
                return req.downloadHandler.data;
            }
            return File.ReadAllBytes(path);
        }

        private static void EnsureFileExists(string path, byte[] bytes)
        {
            if (!File.Exists(path)) File.WriteAllBytes(path, bytes);
        }

        #endregion

        #if UNITY_EDITOR
        [MenuItem("ElysiumDB/Settings")]
        public static void OpenSettings()
        {
            EditorUtility.OpenPropertyEditor(Settings);
        }
        #endif

        // ==================== ОСНОВНОЕ: Очистка ====================
        public void Dispose()
        {
            foreach (var db in Connections.Values)
            {
                try
                {
                    db.Dispose();
                }
                catch { }
            }

            Connections.Clear();

            RunExtensionsProcess(ExtensionEvent.Dispose);

            if (Instance == this)
                Instance = null;
        }

        ~ElysiumDatabase()
        {
            Dispose();
        }
    }
}