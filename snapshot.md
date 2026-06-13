# Project Snapshot

## Structure

```
.
├──  Attributes
│   ├──  DefaultExtensionGroupAttribute.cs
│   ├──  ExtensionProcessOrderAttribute.cs
│   └──  RequireExtensionAttribute.cs
├──  Core
│   ├──  DBMeta.cs
│   ├──  ElysiumDatabase.cs
│   └──  Settings
│       ├──  Editor
│       │   └──  ElysiumDBSettingsEditor.cs
│       └──  ElysiumDBSettings.cs
├──  DBExtensionBase.cs
├──  Docs
│   └──  Images
├──  Editor
│   ├──  ExtensionDrawer.cs
│   └──  Internal
│       ├──  Auxilary
│       │   ├──  CustomList.cs
│       │   ├──  DBExtensionBaseDrawer.cs
│       │   ├──  DBExtensionDrawer.cs
│       │   └──  IMGUITextFieldPro.cs
│       └──  DBPostprocessor.cs
├──  Extensions
│   └──  AuthExtension
│       ├──  AuthElysiumDB.cs
│       ├──  AuthElysiumDBDrawer.cs
│       └──  IAuthElysiumReceiver.cs
└──  Internal
    └──  Data
        └──  ExtensionEvent.cs
```

## ./Attributes/DefaultExtensionGroupAttribute.cs

```csharp
using System;

namespace ModuDevCore.ElysiumDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class DefaultExtensionGroupAttribute : Attribute
    {
        public string ExtensionGroup;

        public DefaultExtensionGroupAttribute(string extensionGroup)
        {
            ExtensionGroup = extensionGroup;
        }
    }
}
```

## ./Attributes/ExtensionProcessOrderAttribute.cs

```csharp
using System;

namespace ModuDevCore.ElysiumDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ExtensionProcessOrderAttribute : Attribute
    {
        public string Group { get; }
        public int Order { get; }

        public ExtensionProcessOrderAttribute(string group, int order = 0)
        {
            Group = group ?? "Default";
            Order = order;
        }
    }
}
```

## ./Attributes/RequireExtensionAttribute.cs

```csharp
using System;

namespace ModuDevCore.ElysiumDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class RequireExtensionAttribute : Attribute
    {
        public Type ExtensionType;

        public bool AutoCreate;

        public RequireExtensionAttribute(Type extensionType, bool autoCreate = true)
        {
            ExtensionType = extensionType;
            AutoCreate = autoCreate;
        }
    }
}
```

## ./Core/DBMeta.cs

```csharp
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Reflection;

using UnityEngine;

namespace ModuDevCore.ElysiumDB 
{
    public class DBMeta : IDisposable
    {
        public IDbConnection connection;

        private bool ShouldIgnoreLog(string log)
        {
            var ignores = ElysiumDatabase.Settings?.logIgnorePatterns;
            var showLogs = ElysiumDatabase.Settings?.showLogs??true;
            if (ignores == null || ignores.Count == 0 || !showLogs)
                return false;

            for (int i = 0; i < ignores.Count; i++)
            {
                var pattern = ignores[i];

                if (!string.IsNullOrEmpty(pattern) &&
                    (
                        log.Contains(pattern, StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    return true;
                }
            }

            return false;
        }
        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }

        public IDataReader Query(
            string cmd,
            int linesToRead = 0,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            string file = System.IO.Path.GetFileName(callerFile);

            if (!ShouldIgnoreLog(
                    $"LiteSQL request\n" +
                    $"QUERY: {cmd}\n" +
                    $"DB: {connection.ConnectionString}\n" +
                    $"CALLED FROM: {file}:{callerLine} ({callerMethod})"
                )
            )
            {
                Debug.Log(
                    $"LiteSQL request\n" +
                    $"QUERY: {cmd}\n" +
                    $"DB: {connection.ConnectionString}\n" +
                    $"CALLED FROM: {file}:{callerLine} ({callerMethod})"
                );
            }

            IDbCommand dbcmd = connection.CreateCommand();
            dbcmd.CommandText = cmd;
            IDataReader reader = dbcmd.ExecuteReader();

            for (int i = 0; i < linesToRead; i++)
                reader.Read();

            return reader;
        }
        public T QueryFirst<T>(
            string cmd,
            int linesToRead = 0,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        ) where T : new()
        {
            using IDataReader reader = Query(cmd, linesToRead, callerMethod, callerFile, callerLine);

            if (!reader.Read())
                return default;

            return MapReaderToObject<T>(reader);
        }
        public List<T> QueryList<T>(
            string cmd,
            int linesToRead = 0,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        ) where T : new()
        {
            List<T> result = new();

            using IDataReader reader = Query(cmd, linesToRead, callerMethod, callerFile, callerLine);

            while (reader.Read())
            {
                result.Add(MapReaderToObject<T>(reader));
            }

            return result;
        }
        public List<T> QueryColumn<T>(string cmd)
        {
            List<T> result = new();

            using IDataReader reader = Query(cmd);

            while (reader.Read())
            {
                object value = reader.GetValue(0);

                if (value == null || value == DBNull.Value)
                    continue;

                result.Add((T)Convert.ChangeType(value, typeof(T)));
            }

            return result;
        }
        public T QueryValue<T>(
            string cmd,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            using IDataReader reader = Query(cmd, 0, callerMethod, callerFile, callerLine);

            if (!reader.Read())
                return default;

            object value = reader.IsDBNull(0)
                ? null
                : reader.GetValue(0);

            if (value == null)
                return default;

            return (T)Convert.ChangeType(value, typeof(T));
        }
        public Dictionary<TKey, TValue> QueryDictionary<TKey, TValue>(
            string cmd,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            Dictionary<TKey, TValue> result = new();

            using IDataReader reader = Query(cmd, 0, callerMethod, callerFile, callerLine);

            while (reader.Read())
            {
                TKey key = (TKey)Convert.ChangeType(reader.GetValue(0), typeof(TKey));
                TValue value = (TValue)Convert.ChangeType(reader.GetValue(1), typeof(TValue));

                result[key] = value;
            }

            return result;
        }
        public void Execute(string cmd)
        {
            using var dbcmd = connection.CreateCommand();
            dbcmd.CommandText = cmd;
            dbcmd.ExecuteNonQuery();
        }
        public bool Exists(string cmd)
        {
            using IDataReader reader = Query(cmd);
            return reader.Read();
        }
        private static T MapReaderToObject<T>(IDataReader reader)
            where T : new()
        {
            T item = new();

            var properties = typeof(T)
                .GetProperties(BindingFlags.Public |
                               BindingFlags.Instance);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);

                var property = properties.FirstOrDefault(p =>
                    string.Equals(
                        p.Name,
                        columnName,
                        StringComparison.OrdinalIgnoreCase));

                if (property == null || !property.CanWrite)
                    continue;

                object value = reader.IsDBNull(i)
                    ? null
                    : reader.GetValue(i);

                try
                {
                    if (value != null)
                    {
                        Type targetType =
                            Nullable.GetUnderlyingType(property.PropertyType)
                            ?? property.PropertyType;

                        value = Convert.ChangeType(value, targetType);
                    }

                    property.SetValue(item, value);
                }
                catch
                {
                }
            }

            return item;
        }
    }
}
```

## ./Core/ElysiumDatabase.cs

```csharp
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;

using LiteSQLCustom;

namespace ModuDevCore.ElysiumDB 
{
	using Extension;
	using Core.Settings;
	using Internal.Data;

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

		    if (!Settings.extensions.Any(e => e?.GetType() == type))
		    {
		        EditorUtility.SetDirty(Settings);
		    }

		    Debug.Log($"[ElysiumDB] Extension added: {type.Name}");
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

		    Debug.Log($"[ElysiumDB] Extension removed: {type.Name}");
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
		    var assemblies = AppDomain.CurrentDomain.GetAssemblies();

		    foreach (var ext in Settings.extensions)
		    {
		        Type type = ext.GetType();

	            var attributes =
	                (RequireExtensionAttribute[])
	                type.GetCustomAttributes(typeof(RequireExtensionAttribute), true);

	            foreach (var attribute in attributes)
	            {
	                if (!typeof(DBExtensionBase).IsAssignableFrom(attribute.ExtensionType))
	                {
	                    Debug.LogError(
	                        $"[ElysiumDB] {attribute.ExtensionType.Name} is not DBExtensionBase.");
	                    continue;
	                }

	                bool exists =
	                    Settings.extensions.Any(e =>
	                        e != null &&
	                        e.GetType() == attribute.ExtensionType);

	                if (exists)
	                    continue;

	                if (attribute.AutoCreate)
	                {
	                    var extension =
	                        (DBExtensionBase)Activator.CreateInstance(attribute.ExtensionType);

	                    Settings.extensions.Add(extension);

	#if UNITY_EDITOR
	                    UnityEditor.EditorUtility.SetDirty(Settings);
	#endif

	                    Debug.Log(
	                        $"[ElysiumDB] Auto created extension: {attribute.ExtensionType.Name}");
	                }
	                else
	                {
	                    Debug.LogError(
	                        $"[ElysiumDB] Required extension missing: {attribute.ExtensionType.Name}");
	                }
	            }
		    }
		}

        public void New()
        {
            Debug.Log("Initializing ElysiumDB...");

            foreach (var db in Connections.Values)
                try { db.Dispose(); } catch { }

            Connections.Clear();
            RunExtensionsProcess(ExtensionEvent.Initialize);

            foreach (var path in Settings.dbPaths)
            {
                ConnectDB(path);
            }

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

            var conn = new SqliteConnectionNative {
                ConnectionString = destPath
            };
            try {
                conn.Open();
                Connections[path] = new DBMeta { connection = conn };
                Debug.Log($"DB loaded: {path}");
            } catch(Exception e) {
                Debug.Log($"DB exception: {conn.ConnectionString} \n {e}");
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

        [MenuItem("ElysiumDB/Settings")]
        public static void OpenSettings()
        {
            EditorUtility.OpenPropertyEditor(Settings);
        }

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
```

## ./Core/Settings/Editor/ElysiumDBSettingsEditor.cs

```csharp
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

using UnityEditor;
using UnityEngine;

using ModuDevCore.ElysiumDB.Extension;
using ModuDevCore.ElysiumDB.Editor.Internal;
using ModuDevCore.ElysiumDB.Editor.Internal.GUI.List;

namespace ModuDevCore.ElysiumDB.Core.Settings.Editor
{
    [CustomEditor(typeof(ElysiumDBSettings))]
    public class ElysiumDBSettingsEditor : UnityEditor.Editor
    {
        ElysiumDBSettings elysiumDBSettings;

        public CustomList listLogsFilter;
        public CustomList listOfPathDB;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            elysiumDBSettings = (ElysiumDBSettings) target;
            if(listOfPathDB == null)
                listOfPathDB = new CustomList(serializedObject.FindProperty("dbPaths"), "Database Paths", serializedObject, Application.streamingAssetsPath+"/{DB Name}");
            if(listLogsFilter == null)
                listLogsFilter = new CustomList(serializedObject.FindProperty("logIgnorePatterns"), "Logs Filter", serializedObject);


            EditorGUILayout.LabelField("Elysium DB Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space(5);

            listLogsFilter.Draw();
            SerializedProperty showLogs = serializedObject.FindProperty("showLogs");

            Color oldColor = GUI.backgroundColor;

            GUI.backgroundColor =
                showLogs.boolValue
                ? Color.red
                : Color.green;

            showLogs.boolValue = GUILayout.Toggle(
                showLogs.boolValue,
                (showLogs.boolValue ? "Hide" : "Show") + " Logs",
                GUI.skin.button);

            GUI.backgroundColor = oldColor;

            EditorGUILayout.Space(5);

            listOfPathDB.Draw();


            DrawElysiumDBInfo();
            DrawExtensions();
            serializedObject.ApplyModifiedProperties();
        }
        bool DrawStatus(string label, bool state, string trueText = "TRUE", string falseText = "FALSE")
        {
            EditorGUILayout.BeginHorizontal();
            bool click = false;
            GUI.color =
                state
                ? Color.green
                : Color.red;

            GUILayout.Label(
                "●",
                GUILayout.Width(15));

            GUI.color = Color.white;
            click = GUILayout.Button(label, EditorStyles.label);

            GUILayout.FlexibleSpace();
            
            click = GUILayout.Button(state
                ? trueText
                : falseText, EditorStyles.label) || click;

            EditorGUILayout.EndHorizontal();

            return click;
        }
        void DrawElysiumDBInfo()
        {
            GUILayout.Space(10);

            EditorGUILayout.BeginVertical("box");

            GUILayout.Label(
                "ElysiumDB Info",
                EditorStyles.boldLabel);

            bool initialized =
                ElysiumDatabase.Instance != null;

            if(DrawStatus(
                "Initialized",
                initialized)
            ) {
                if(initialized) {
                    ElysiumDatabase.Instance.Dispose();
                    initialized = false;
                    return;
                } else {                    
                    ElysiumDatabase elysium = new ElysiumDatabase();
                    elysium.New();
                }
            }

            DrawStatus(
                "Internet",
                !ElysiumDatabase.IsOffline);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField(
                "Persistent Path",
                Application.persistentDataPath);

            EditorGUILayout.LabelField(
                "Platform Data Path",
                ElysiumDatabase.PlatformDataPath);

            EditorGUILayout.LabelField(
                "Streaming Assets",
                Application.streamingAssetsPath);

            EditorGUILayout.Space();

            GUILayout.Label(
                "Databases",
                EditorStyles.boldLabel);

            foreach(var path in ElysiumDatabase.Settings.dbPaths) {
                string fullPath =
                        Path.Combine(ElysiumDatabase.PlatformDataPath, path);

                bool exists = File.Exists(
                    Path.Combine(
                        ElysiumDatabase.PlatformDataPath,
                        path));
                bool connected = initialized ? ElysiumDatabase.Instance.Connections.ContainsKey(path) : false;

                EditorGUILayout.BeginHorizontal();

                if (DrawStatus(path, connected, $" ( Connected )", $" ( { (exists ? "Disconnected" : "Missing") } )"))
                {
                    if(connected)
                        ElysiumDatabase.Instance.DetachDB(path);
                    else
                        ElysiumDatabase.Instance.ConnectDB(path);
                }

                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Copy Path", GUILayout.Width(80)))
                {
                    EditorGUIUtility.systemCopyBuffer = fullPath;
                }
                if (GUILayout.Button("Open", GUILayout.Width(60)))
                {
                    ShowOpenMenu(Path.Combine(Application.streamingAssetsPath, path), Path.Combine(ElysiumDatabase.PlatformDataPath, path));
                }


                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();
        }
        void DrawExtensions() {
            GUILayout.Space(10);

            EditorGUILayout.BeginVertical("box");

            GUILayout.Label(
                "Extensions",
                EditorStyles.boldLabel);
            
            DBExtensionDrawer.DrawExtensionsList(
                serializedObject.FindProperty("extensions"),
                typeof(DBExtensionBase));

            EditorGUILayout.EndVertical();
        }
        void ShowOpenMenu(string sourcePath, string runtimePath)
        {
            GenericMenu menu = new GenericMenu();

            if (File.Exists(runtimePath))
            {
                menu.AddItem(
                    new GUIContent("Open Runtime DB"),
                    false,
                    () => OpenFile(runtimePath));
            }
            else
            {
                menu.AddDisabledItem(
                    new GUIContent("Open Runtime DB (Missing)"));
            }

            if (File.Exists(sourcePath))
            {
                menu.AddItem(
                    new GUIContent("Open Source DB"),
                    false,
                    () => OpenFile(sourcePath));
            }
            else
            {
                menu.AddDisabledItem(
                    new GUIContent("Open Source DB (Missing)"));
            }

            menu.ShowAsContext();
        }
        void OpenFile(string path)
        {
            if (!File.Exists(path))
            {
                UnityEngine.Debug.LogWarning($"File not found: {path}");
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }
    }
}
```

## ./Core/Settings/ElysiumDBSettings.cs

```csharp
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using ModuDevCore.ElysiumDB.Extension;

namespace ModuDevCore.ElysiumDB.Core.Settings
{
    public class ElysiumDBSettings : ScriptableObject
    {
        public List<string> logIgnorePatterns = new List<string>();
        public List<string> dbPaths = new List<string>();
        [SerializeReference]
        public List<DBExtensionBase> extensions = new();
        public bool showLogs = true;
    } 
}
```

## ./DBExtensionBase.cs

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

namespace ModuDevCore.ElysiumDB.Extension
{
	using Core;	
	using Internal.Data;	
	[Serializable]
    public class DBExtensionBase
    {
    	[HideInInspector]
    	public bool enabled = true;
    	[HideInInspector]
    	public string extensionGroup = "";
    	[HideInInspector]
    	public int extensionId = -1;
    	public string extensionName => this.GetType().Name;

    	// INTERNAL
	    public void Process(ExtensionEvent ev, ElysiumDatabase еlysium = null)
	    {
	        switch (ev)
	        {
	            case ExtensionEvent.Initialize:
	            	if(!enabled)
	            		break;
	            	Debug.Log($"[DBExtension] Initialize → {extensionName}");
	                OnInitialize(еlysium);
	                break;

	            case ExtensionEvent.Dispose:
	            	Debug.Log($"[DBExtension] Dispose → {extensionName}");
	                OnDispose();
	                break;
	        }
	    }
		public T GetExtension<T>() where T : class
		        => ElysiumDatabase.GetExtension<T>();
		public T[] GetExtensions<T>() where T : class
		        => ElysiumDatabase.GetExtensions<T>();
	    public bool TryGetExtensions<T>(out T[] extensions) where T : class
	    {
	        extensions = ElysiumDatabase.GetExtensions<T>();
	        return extensions.Length > 0;
	    }
		public bool HasExtension<T>() where T : class
		        => ElysiumDatabase.HasExtension<T>();

		public T AddExtension<T>() where T : DBExtensionBase, new()
		        => ElysiumDatabase.AddExtension<T>();
		public bool RemoveExtension<T>() where T : DBExtensionBase, new()
		    => ElysiumDatabase.RemoveExtension<T>();

        protected virtual void OnInitialize(ElysiumDatabase elysium) {}
        protected virtual void OnDispose() {}
		public void Log(object message)
	    {
	        Debug.Log($"[{extensionName}] " + message);
	    }
    }
}
```

## ./Editor/ExtensionDrawer.cs

```csharp
using UnityEngine;
using UnityEditor;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Core.Settings;
using ModuDevCore.ElysiumDB.Extension;

namespace ModuDevCore.ElysiumDB.Editor {
    public abstract class ExtensionDrawer : PropertyDrawer
    {
        protected ElysiumDBSettings Settings =>
            ElysiumDatabase.Settings;

        public object target = null;

        public T GetExtension<T>() where T : class
                => ElysiumDatabase.GetExtension<T>();
        public T[] GetExtensions<T>() where T : class
                => ElysiumDatabase.GetExtensions<T>();
        public bool TryGetExtensions<T>(out T[] extensions) where T : class
        {
            extensions = ElysiumDatabase.GetExtensions<T>();
            return extensions.Length > 0;
        }
        public bool HasExtension<T>() where T : class
                => ElysiumDatabase.HasExtension<T>();
        public T AddExtension<T>() where T : DBExtensionBase, new()
                => ElysiumDatabase.AddExtension<T>();
        public bool RemoveExtension<T>() where T : DBExtensionBase, new()
            => ElysiumDatabase.RemoveExtension<T>();

        public sealed override void OnGUI(
            Rect position,
            SerializedProperty property,
            GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            bool isArrayElement =
                property.propertyPath.Contains(".Array.data[");

            target = property.boxedValue;

            OnExtensionGUI(position, property, label);

            EditorGUI.EndProperty();
        }

        protected virtual void OnExtensionGUI(
            Rect position,
            SerializedProperty property,
            GUIContent label)
        {
        }

        public sealed override float GetPropertyHeight(
            SerializedProperty property,
            GUIContent label)
        {
            return GetExtensionHeight(property, label);
        }

        protected virtual float GetExtensionHeight(
            SerializedProperty property,
            GUIContent label)
        {
            return 0f;
        }

        public void DrawDefaultExtension(
            Rect position,
            SerializedProperty property)
        {
            EditorGUI.indentLevel++;

            SerializedProperty iterator = property.Copy();
            SerializedProperty end = property.GetEndProperty();

            bool enterChildren = true;

            while (iterator.NextVisible(enterChildren))
            {
                if (SerializedProperty.EqualContents(iterator, end))
                    break;

                position.height =
                    EditorGUI.GetPropertyHeight(iterator, true);

                EditorGUI.PropertyField(position, iterator, true);

                position.y += position.height +
                              EditorGUIUtility.standardVerticalSpacing;

                enterChildren = false;
            }

            EditorGUI.indentLevel--;
        }

        public float GetChildrenHeight(
            SerializedProperty property)
        {
            float total = 0f;

            SerializedProperty iterator = property.Copy();
            SerializedProperty end = property.GetEndProperty();

            bool enterChildren = true;

            while (iterator.NextVisible(enterChildren))
            {
                if (SerializedProperty.EqualContents(iterator, end))
                    break;

                total +=
                    EditorGUI.GetPropertyHeight(iterator, true) +
                    EditorGUIUtility.standardVerticalSpacing;

                enterChildren = false;
            }

            return total - EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
```

## ./Editor/Internal/Auxilary/CustomList.cs

```csharp
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

using ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text;

namespace ModuDevCore.ElysiumDB.Editor.Internal.GUI.List
{
    public class CustomList
    {
        private int _focusIndex = -1;
        private bool _focusRequested;
        private bool _selectRequested;

        private SerializedProperty _list;
        private SerializedObject _serializedObject;
        private string _label;
        private string _placeholder;
        private Dictionary<string, IMGUITextFieldPro> tfps = new();
        private HashSet<string> _usedThisFrame = new();

        public CustomList(SerializedProperty list, string label, SerializedObject serializedObject, string placeholder = "")
        {
            _list = list;
            _label = label;
            _serializedObject = serializedObject;
            _placeholder = placeholder;
        }

        IMGUITextFieldPro DrawTextField(string name, string content, string placeholder = "")
        {
            _usedThisFrame.Add(name);

            if (!tfps.TryGetValue(name, out var field))
            {
                field = new IMGUITextFieldPro(name, "", placeholder);
                tfps[name] = field;
            }

            field.text = content;

            field.Draw();

            return field;
        }
        void CleanupUnused()
        {
            var keysToRemove = tfps.Keys
                .Where(k => !_usedThisFrame.Contains(k))
                .ToList();

            foreach (var key in keysToRemove)
            {
                tfps.Remove(key);
            }

            _usedThisFrame.Clear();
        }

        public void Draw()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField(_label, EditorStyles.boldLabel);
            EditorGUILayout.Space(10);

            bool keyPressed = false;
            for (int i = 0; i < _list.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal("box");

                string contentName = $"{_label}_{i}";
                var element = _list.GetArrayElementAtIndex(i);
                IMGUITextFieldPro tfp = DrawTextField(contentName, element.stringValue);
                element.stringValue = tfp.text;

                if (_focusRequested && _focusIndex == i)
                {
                    if (Event.current.type == EventType.Repaint)
                    {
                        tfp.Focus();
                        _focusRequested = false;
                        if(_selectRequested) {
                            tfp.SetSelection(0, tfp.text.Length);
                            _selectRequested = false;
                        }
                    }
                }
                if(tfp.hasFocus && !keyPressed) {
                    if (Event.current.type == EventType.KeyDown)
                    {
                        switch(Event.current.keyCode) {
                            case KeyCode.UpArrow:
                                _focusIndex = i - 1;
                                _focusRequested = true;
                                _selectRequested = true;
                                keyPressed = true;
                            break;
                            case KeyCode.DownArrow:
                                _focusIndex = i + 1;
                                _focusRequested = true;
                                _selectRequested = true;
                                keyPressed = true;
                            break;
                        }
                    }
                }

                if (element.stringValue == "" || GUILayout.Button("X", GUILayout.Width(25)))
                {
                    _focusIndex = Mathf.Clamp(i - 1, 0, _list.arraySize - 2);
                    _focusRequested = true;
                    _selectRequested = true;
                    _list.DeleteArrayElementAtIndex(i);
                    _serializedObject.ApplyModifiedProperties();
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space();
            IMGUITextFieldPro tfpNewValue = DrawTextField($"{_label}_newValue", "", _placeholder);

            if (!string.IsNullOrEmpty(tfpNewValue.text))
            {
                int newIndex = _list.arraySize;
                _list.arraySize++;

                var element = _list.GetArrayElementAtIndex(newIndex);
                element.stringValue = tfpNewValue.text;

                _focusIndex = newIndex;
                _focusRequested = true;
            }

            EditorGUILayout.EndVertical();
            CleanupUnused();
        }
    }
}
```

## ./Editor/Internal/Auxilary/DBExtensionBaseDrawer.cs

```csharp
using UnityEngine;
using UnityEditor;
using ModuDevCore.ElysiumDB.Extension;
using ModuDevCore.ElysiumDB.Editor.Internal.GUI.List;
using ModuDevCore.ElysiumDB.Editor;

namespace ModuDevCore.ElysiumDB.Editor.Internal {
    [CustomPropertyDrawer(typeof(DBExtensionBase), true)]
    public class DBExtensionBaseDrawer : ExtensionDrawer
    {
        protected override void OnExtensionGUI(
            Rect position, 
            SerializedProperty property, 
            GUIContent label)
        {
            DrawDefaultExtension(position, property);
        }
        protected override float GetExtensionHeight(
            SerializedProperty property,
            GUIContent label)
        {
            return GetChildrenHeight(property);
        }
    }
}
```

## ./Editor/Internal/Auxilary/DBExtensionDrawer.cs

```csharp
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEditor.IMGUI.Controls;
using ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text;

namespace ModuDevCore.ElysiumDB.Editor.Internal
{
    public interface IInspectorElement
    {
        bool IsGroup { get; }
        bool IsExtension { get; }
        int Index { get; set; }
    }

    public class PropertyGroup : IInspectorElement
    {
        public string GroupName { get; set; }
        public bool IsGroup => true;
        public bool IsExtension => false;
        public int Index { get; set; }
        public List<IInspectorElement> Elements = new List<IInspectorElement>();

        public void DeleteGroup() {
            Stack<PropertyGroup> stack = new Stack<PropertyGroup>();
            stack.Push(this);

            int nestingIndex = 0;

            while (stack.Count > 0)
            {
                PropertyGroup current = stack.Pop();

                foreach (var element in current.Elements)
                {
                    if (element is PropertyExtension extension)
                    {
                        var groupProp = extension.SerializedProperty.FindPropertyRelative("extensionGroup");
                        if (groupProp != null && !string.IsNullOrEmpty(groupProp.stringValue))
                        {   
                            List<string> parts = groupProp.stringValue.Split('/').ToList();
                            
                            parts.RemoveAt(parts.Count - 1 - nestingIndex);

                            groupProp.stringValue = string.Join("/", parts);
                            
                            if (groupProp.serializedObject != null)
                                groupProp.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    else if (element is PropertyGroup subGroup)
                    {
                        stack.Push(subGroup);
                    }
                }
                nestingIndex += 1;
            }
        }

        public void MigrateToNewGroupName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return;

            newName = newName.Trim();
            if (newName == GroupName) return;

            GroupName = newName;

            Stack<PropertyGroup> stack = new Stack<PropertyGroup>();
            stack.Push(this);
            
            int nestingIndex = 0;
            
            while (stack.Count > 0)
            {
                PropertyGroup current = stack.Pop();

                foreach (var element in current.Elements)
                {
                    if (element is PropertyExtension extension)
                    {
                        var groupProp = extension.SerializedProperty.FindPropertyRelative("extensionGroup");
                        if (groupProp != null && !string.IsNullOrEmpty(groupProp.stringValue))
                        {   
                            string[] parts = groupProp.stringValue.Split('/');
                                
                            parts[parts.Length - 1 - nestingIndex] = newName;

                            groupProp.stringValue = string.Join("/", parts);
                            
                            if (groupProp.serializedObject != null)
                                groupProp.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    else if (element is PropertyGroup subGroup)
                    {
                        stack.Push(subGroup);
                    }
                }
                nestingIndex += 1;
            }
        }
    }

    public class PropertyExtension : IInspectorElement
    {
        public bool IsGroup => false;
        public bool IsExtension => true;
        public int Index { get; set; }

        public SerializedProperty SerializedProperty { get; set; }
    }
    public static class SerializedPropertyExtensions
    {
    public static int IndexOf(this SerializedProperty arrayProperty, SerializedProperty elementToFind)
    {
            if (arrayProperty == null || !arrayProperty.isArray || elementToFind == null)
            return -1;

            for (int i = 0; i < arrayProperty.arraySize; i++)
            {
                SerializedProperty current = arrayProperty.GetArrayElementAtIndex(i);

                // Сравниваем содержимое
                if (SerializedProperty.EqualContents(current, elementToFind))
                    return i;
            }

            return -1;
        }
    } 
    public static class DBExtensionDrawer
    {
        private static readonly Dictionary<string, bool> _expandedStates = new Dictionary<string, bool>(StringComparer.Ordinal);
        private static readonly Dictionary<Type, Texture2D> _iconCache = new Dictionary<Type, Texture2D>();
        private static Texture2D _defaultScriptIcon;

        public static List<IInspectorElement> inspectorElements = new List<IInspectorElement>();

        private static readonly Dictionary<Type, string> _scriptGuidCache = new Dictionary<Type, string>();

        private static Dictionary<string, IMGUITextFieldPro> tfps = new();
        private static HashSet<string> _usedThisFrame = new();
        private static string GetScriptUniqueGUID(Type type, string instanceId)
        {
            if (type == null)
                return "null_type";

            if (string.IsNullOrEmpty(instanceId))
                instanceId = "no_instance";

            // Кэшируем только GUID скрипта по типу (instanceId не кэшируем)
            if (_scriptGuidCache.TryGetValue(type, out string cachedGuid))
            {
                return cachedGuid + "_" + instanceId;
            }

            // Основной поиск по имени
            string[] guids = AssetDatabase.FindAssets($"t:script {type.Name}");
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);

                if (script != null && script.GetClass() == type)
                {
                    _scriptGuidCache[type] = guid;
                    return guid + "_" + instanceId;
                }
            }

            // Fallback: поиск по полному имени
            if (!string.IsNullOrEmpty(type.FullName))
            {
                guids = AssetDatabase.FindAssets("t:script");
                foreach (string guid in guids)
                {
                    string path = AssetDatabase.GUIDToAssetPath(guid);
                    MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);

                    if (script != null && script.GetClass()?.FullName == type.FullName)
                    {
                        _scriptGuidCache[type] = guid;
                        return guid + "_" + instanceId;
                    }
                }
            }

            // Финальный fallback
            string fallback = type.FullName ?? type.Name ?? "unknown_type";
            _scriptGuidCache[type] = fallback;
            return fallback + "_" + instanceId;
        }
        private static bool GetExpanded(string fullPath, bool defaultValue = true)
        {
            if (string.IsNullOrEmpty(fullPath))
                return defaultValue;

            if (_expandedStates.TryGetValue(fullPath, out bool value))
                return value;

            _expandedStates[fullPath] = true;
            return true;
        }

        private static void SetExpanded(string fullPath, bool expanded)
        {
            if (string.IsNullOrEmpty(fullPath)) return;

            _expandedStates[fullPath] = expanded;
        }

        private static IMGUITextFieldPro DrawTextField(Rect rect, string name, string placeholder = "")
        {
            // MARK: элемент использован в этом кадре
            _usedThisFrame.Add(name);

            if (!tfps.TryGetValue(name, out var field))
            {
                field = new IMGUITextFieldPro(name, "", placeholder, false);
                tfps[name] = field;
            }

            field.Draw(rect);

            field.drawBackground = field.hasFocus;
            field.FocusAccentColor = new Color(0,0,0,0);

            return field;
        }

        public static bool TryGetGroup(string groupName, out IInspectorElement group)
        {
            group = null;

            if (string.IsNullOrWhiteSpace(groupName))
                return false;

            foreach (var element in inspectorElements)
            {
                if(element is PropertyGroup propertyGroup)
                    if (string.Equals(propertyGroup.GroupName, groupName, StringComparison.OrdinalIgnoreCase))
                    {
                        group = element;
                        return true;
                    }
            }

            return false;
        }

        public static void ValidateGroups(SerializedProperty property)
        {
            if (property == null || !property.isArray) 
                return;
            inspectorElements.Clear();
            for (int i = 0; i < property.arraySize; i++)
            {
                SerializedProperty element = property.GetArrayElementAtIndex(i);
                SerializedProperty groupProp = element.FindPropertyRelative("extensionGroup");
                
                if(groupProp?.name == null)
                    continue;

                string groupPath = groupProp.stringValue?.Trim() ?? "";
                if (string.IsNullOrEmpty(groupPath)) {
                    // Is extension
                    inspectorElements.Add(
                        new PropertyExtension() {
                            Index = i,
                            SerializedProperty = element
                        }
                    );
                }
                else 
                {
                    string[] parts = groupPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 0)
                        continue;

                    // Начинаем с корневого уровня
                    List<IInspectorElement> currentLevel = inspectorElements;
                    PropertyGroup currentGroup = null;

                    for (int depth = 0; depth < parts.Length; depth++)
                    {
                        string groupName = parts[depth];

                        // Ищем существующую группу на текущем уровне
                        currentGroup = currentLevel.OfType<PropertyGroup>()
                            .FirstOrDefault(g => g.GroupName == groupName);

                        if (currentGroup == null)
                        {
                            // Создаём новую группу
                            currentGroup = new PropertyGroup
                            {
                                GroupName = groupName,
                                Index = i,                    // или можно использовать depth
                                Elements = new List<IInspectorElement>()
                            };

                            currentLevel.Add(currentGroup);
                        }

                        // Если это последний уровень пути — добавляем сам элемент
                        if (depth == parts.Length - 1)
                        {
                            currentGroup.Elements.Add(new PropertyExtension
                            {
                                Index = i,
                                SerializedProperty = element
                            });
                        }
                        else
                        {
                            // Иначе спускаемся на следующий уровень
                            currentLevel = currentGroup.Elements;
                        }
                    }
                }
            }
        }
        public static string GenerateNewGroupName(IEnumerable<IInspectorElement> elements)
        {
            if (elements == null || !elements.Any())
                return "New Group 1";

            int maxNumber = 0;
            Regex regex = new Regex(@"^New Group (\d+)$", RegexOptions.IgnoreCase);

            foreach (var element in elements)
            {
                if (element is PropertyGroup group && !string.IsNullOrWhiteSpace(group.GroupName))
                {
                    Match match = regex.Match(group.GroupName.Trim());
                    if (match.Success)
                    {
                        if (int.TryParse(match.Groups[1].Value, out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"New Group {maxNumber + 1}";
        }

        public static void DrawExtensionsList(
            SerializedProperty property,
            Type baseType)
        {
            if (property == null) return;
            if (!property.isArray)
            {
                EditorGUILayout.HelpBox($"{property.displayName} is not array/list", MessageType.Error);
                return;
            }

            ValidateGroups(property);

            inspectorElements.Sort((a, b) => a.Index.CompareTo(b.Index));

            DrawInspectorElements(property, inspectorElements);
            GUILayout.Space(6);
            DrawAddPanel(property, baseType);
        }

        /// <summary>
        /// Рекурсивная отрисовка элементов с поддержкой вложенных групп
        /// </summary>
        private static void DrawInspectorElements(SerializedProperty property, List<IInspectorElement> elements, string parentPath = "")
        {
            for (int i = 0; i < elements.Count; i++)
            {
                IInspectorElement inspectorElement = elements[i];

                if (inspectorElement is PropertyExtension propertyExtension)
                {
                    // Обычное расширение (не в группе)
                    DrawExtension(property, propertyExtension.Index, i, elements, parentPath);
                }
                else if (inspectorElement is PropertyGroup propertyGroup)
                {
                    string currentPath = string.IsNullOrEmpty(parentPath) 
                        ? propertyGroup.GroupName 
                        : parentPath + "/" + propertyGroup.GroupName;
                    bool isEnabled = true;
                    bool isExpanded = GetExpanded(currentPath);

                    string headerLabel = propertyGroup.GroupName;

                    DrawHeader(
                        labelRect => {
                            if(tfps.TryGetValue(currentPath, out var field)) {
                                float width = field.textStyle.CalcSize(new GUIContent(field.text)).x;
                                labelRect.width = width + 8;
                            }
                            field = DrawTextField(labelRect, currentPath);
                            if(!field.hasFocus) {
                                if(field.text != headerLabel && !string.IsNullOrEmpty(field.text)){
                                    propertyGroup.MigrateToNewGroupName(field.text);
                                }
                                field.text = headerLabel;
                            }
                            // EditorGUI.LabelField(labelRect, headerLabel, EditorStyles.boldLabel);
                            return labelRect;
                        },
                        () => ShowContextMenuGroup(property, propertyGroup.Index, i, elements, propertyGroup),
                        ref isEnabled,
                        ref isExpanded,
                        null,
                        true
                    );


                    SetExpanded(currentPath, isExpanded);

                    if (isExpanded)
                    {
                        EditorGUI.indentLevel++;
                        DrawInspectorElements(property, propertyGroup.Elements, currentPath); // Рекурсия
                        EditorGUI.indentLevel--;
                    }
                }
            }
        }
        private static void DrawExtension(SerializedProperty property, int indexExtension, int inspectorElementsIndex, List<IInspectorElement> elements, string parentPath)
        {

            SerializedProperty element = property.GetArrayElementAtIndex(indexExtension);
            SerializedProperty groupProp = element.FindPropertyRelative("extensionGroup");
            SerializedProperty extensionIdProp = element.FindPropertyRelative("extensionId");
            object boxed = element.boxedValue;
            Type targetType = boxed?.GetType();
            string currentPath = string.IsNullOrEmpty(parentPath) 
                ? GetScriptUniqueGUID(targetType, extensionIdProp.intValue.ToString()) 
                : parentPath + "/" + GetScriptUniqueGUID(targetType, extensionIdProp.intValue.ToString());

            string typeName = boxed != null ? boxed.GetType().Name : "Null";
            Texture2D icon = GetClassIcon(boxed?.GetType());
            SerializedProperty enabledProp = element.FindPropertyRelative("enabled");
            bool stockIsEnabled = enabledProp != null ? enabledProp.boolValue : true;
            bool isEnabled = enabledProp != null ? enabledProp.boolValue : true;
            bool isExpanded = GetExpanded(currentPath);

            GUIContent label = new GUIContent(
                ObjectNames.NicifyVariableName(typeName),
                icon,
                $"Type: {typeName}\nFull Name: {boxed?.GetType().FullName ?? "Null"}"
            );
            EditorGUI.BeginChangeCheck();
            // ObjectNames.NicifyVariableName(typeName)
            DrawHeader(
                labelRect => {
                    EditorGUI.LabelField(labelRect, ObjectNames.NicifyVariableName(typeName), EditorStyles.boldLabel);
                    return labelRect;
                },
                () => ShowContextMenuExtension(property, indexExtension, groupProp, targetType, inspectorElementsIndex, elements), 
                ref isEnabled, 
                ref isExpanded,  
                icon
            );
            SetExpanded(currentPath, isExpanded);

            if (EditorGUI.EndChangeCheck() && enabledProp != null)
            {
                enabledProp.boolValue = isEnabled;
                enabledProp.serializedObject.ApplyModifiedProperties();
            }

            // ==================== DRAW PROPERTY ====================
            if (isExpanded && isEnabled)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(element, label, true);
                EditorGUI.indentLevel--;
            }
        }
        private static Rect DrawHeader(
            Func<Rect, Rect> DrawHeaderLabel,
            Action ShowContextMenu,
            ref bool isEnabled,
            ref bool isExpanded,
            Texture2D icon,
            bool ignoreFoldoutWhenLabelClicked = false
        ) {
            // === Основная строка ===
            Rect headerRect = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight * 1.25f);
            
            headerRect = EditorGUI.IndentedRect(headerRect);
            UnityEngine.GUI.Box(headerRect, GUIContent.none, EditorStyles.helpBox); // рисуем helpBox вручную

            Rect contentRect = headerRect;
            contentRect.xMin += 20;   // небольшой отступ от края helpBox
            // ==================== LEFT SIDE ====================
            Rect foldoutRect = new Rect(contentRect) { width = contentRect.width - 50 };
            
            UnityEngine.GUI.enabled = isEnabled;
            int indent = EditorGUI.indentLevel;

            UnityEngine.GUI.enabled = true;

            // Icon + Label
            Rect labelRect = contentRect;
            
            labelRect.xMin += 5; // место под foldout + небольшой отступ
            if (icon != null)
            {
                float iconSize = headerRect.height * 0.75f;
                Rect iconRect = new Rect(labelRect.x, labelRect.y + (labelRect.height - iconSize) * 0.5f, iconSize, iconSize);
                UnityEngine.GUI.DrawTexture(iconRect, icon, ScaleMode.ScaleToFit);
                labelRect.xMin += 25; // место под foldout + небольшой отступ
            }
            EditorGUI.indentLevel = 0;
            labelRect = DrawHeaderLabel(labelRect);
            Event e = Event.current;

            if(!(ignoreFoldoutWhenLabelClicked && e.type == EventType.MouseDown && labelRect.Contains(e.mousePosition))) {            
                if (isEnabled)
                    isExpanded = EditorGUI.Foldout(foldoutRect, isExpanded, GUIContent.none, true);
                else
                    EditorGUI.Foldout(foldoutRect, false, GUIContent.none, true);
            }


            EditorGUI.indentLevel = indent;

            // ==================== RIGHT SIDE ====================
            Rect rightSideRect = contentRect;
            rightSideRect.xMin = contentRect.xMax - 50;
            rightSideRect.width = 50;

            isEnabled = UnityEngine.GUI.Toggle(new Rect(rightSideRect.x, rightSideRect.y, 20, rightSideRect.height), 
                                  isEnabled, GUIContent.none);

            if (UnityEngine.GUI.Button(new Rect(rightSideRect.x + 26, rightSideRect.y, 24, rightSideRect.height), "⋮"))
            {
                ShowContextMenu();
            }
            return headerRect;
        }

        public static void ShowContextMenuGroup(
            SerializedProperty property, 
            int currentIndex, 
            int inspectorElementsIndex,
            List<IInspectorElement> elements,
            PropertyGroup propertyGroup
        ) 
        {
            GenericMenu menu = new GenericMenu();

            // Удалить
            menu.AddItem(new GUIContent("Delete"), false, () =>
            {
                propertyGroup.DeleteGroup();
            });

            // Вверх
            menu.AddItem(new GUIContent("Move Up"), false, () =>
            {
                if (currentIndex > 0 && inspectorElementsIndex > 0)
                {
                    int targetIndex = elements[inspectorElementsIndex - 1].Index;
                    
                    property.MoveArrayElement(currentIndex, targetIndex);
                    property.serializedObject.ApplyModifiedProperties();
                }
            });

            // Вниз
            menu.AddItem(new GUIContent("Move Down"), false, () =>
            {
                if (currentIndex < property.arraySize - 1 && inspectorElementsIndex < elements.Count - 1)
                {
                    int targetIndex = elements[inspectorElementsIndex + 1].Index;
                    
                    property.MoveArrayElement(currentIndex, targetIndex);
                    property.serializedObject.ApplyModifiedProperties();
                }
            });
            menu.ShowAsContext();
        }
        public static void ShowContextMenuExtension(
            SerializedProperty property, 
            int currentIndex, 
            SerializedProperty groupProp, 
            Type targetType, 
            int inspectorElementsIndex, 
            List<IInspectorElement> elements
        )
        {
            GenericMenu menu = new GenericMenu();

            // Удалить
            menu.AddItem(new GUIContent("Delete"), false, () =>
            {
                if (targetType != null)
                {
                    List<Type> dependents = ElysiumDatabase.GetRequiresExtensions(targetType);

                    if (dependents != null && dependents.Count > 0 && ElysiumDatabase.Settings.extensions.Where(ext => ext != null && ext.GetType() == targetType).ToArray().Length == 1)
                    {
                        string dependentNames = string.Join(", ",
                            dependents.Select(t => t.Name));

                        EditorUtility.DisplayDialog(
                            "Cannot Remove Extension",
                            $"This extension is required by:\n\n{dependentNames}",
                            "OK"
                        );
                        return; // блокируем удаление
                    }
                }
                property.DeleteArrayElementAtIndex(currentIndex);
                property.serializedObject.ApplyModifiedProperties();
                DBPostprocessor.SafetyFixExtensions();
            });

            // Вверх
            menu.AddItem(new GUIContent("Move Up"), false, () =>
            {
                if (currentIndex > 0 && inspectorElementsIndex > 0)
                {
                    int targetIndex = elements[inspectorElementsIndex - 1].Index;
                    
                    property.MoveArrayElement(currentIndex, targetIndex);
                    property.serializedObject.ApplyModifiedProperties();
                }
            });

            // Вниз
            menu.AddItem(new GUIContent("Move Down"), false, () =>
            {
                if (currentIndex < property.arraySize - 1 && inspectorElementsIndex < elements.Count - 1)
                {
                    int targetIndex = elements[inspectorElementsIndex + 1].Index;
                    
                    property.MoveArrayElement(currentIndex, targetIndex);
                    property.serializedObject.ApplyModifiedProperties();
                }
            });

            string targetPath = groupProp.stringValue?.Trim() ?? "";

            int targetLevel = string.IsNullOrEmpty(targetPath) ? 1 : targetPath.Split('/').Length + 1;

            // Заполняем стек корневыми элементами
            Stack<(IInspectorElement element, string currentPath)> stack = new Stack<(IInspectorElement element, string currentPath)>();

            for (int i = inspectorElements.Count - 1; i >= 0; i--)
            {
                stack.Push((inspectorElements[i], ""));
            }

            while (stack.Count > 0)
            {
                var (element, parentPath) = stack.Pop();

                if (element is PropertyGroup group)
                {
                    string fullPath = string.IsNullOrEmpty(parentPath)
                        ? group.GroupName
                        : parentPath + "/" + group.GroupName;

                    // Подсчёт уровня
                    int currentLevel = string.IsNullOrEmpty(fullPath) ? 0 : fullPath.Split('/').Length;

                    // Добавляем только группы нужного уровня
                    if (currentLevel == targetLevel)
                    {
                        menu.AddItem(new GUIContent("Move to Group/" + fullPath.Replace("/", "\\")), false, () =>
                        {
                            groupProp.stringValue = fullPath;
                            property.serializedObject.ApplyModifiedProperties();
                        });
                    }

                    // Продолжаем обход детей
                    for (int j = group.Elements.Count - 1; j >= 0; j--)
                    {
                        stack.Push((group.Elements[j], fullPath));
                    }
                }
            }
            if(!string.IsNullOrEmpty(groupProp.stringValue))
                menu.AddItem(new GUIContent("Move to Group/" + $".."), false, () =>
                {
                    List<string> parts = groupProp.stringValue.Split('/').ToList();
                    parts.RemoveAt(parts.Count - 1);
                    groupProp.stringValue = string.Join("/", parts);
                    property.serializedObject.ApplyModifiedProperties();
                });
            menu.AddItem(new GUIContent("Move to Group/+ Create Group"), false, () =>
            {
                List<string> parts = groupProp.stringValue.Split('/').ToList();
                parts.Add(GenerateNewGroupName(inspectorElements));
                groupProp.stringValue = string.Join("/", parts);
                
                property.serializedObject.ApplyModifiedProperties();
            });
            menu.ShowAsContext();
        }

        // =========================================================
        // ADD PANEL
        // =========================================================

        private static void DrawAddPanel(
            SerializedProperty property,
            Type baseType)
        {
            List<Type> types = TypeCache
                .GetTypesDerivedFrom(baseType)
                .Where(x =>
                    !x.IsAbstract &&
                    !x.IsGenericType)
                .ToList();

            if (types.Count == 0)
            {
                EditorGUILayout.HelpBox(
                    $"No types derived from {baseType.Name}",
                    MessageType.Info);

                return;
            }

            // =========================================================
            // ADD BUTTON (CENTERED + MENU)
            // =========================================================

            EditorGUILayout.BeginHorizontal();

            GUILayout.FlexibleSpace();

            Rect addRect = GUILayoutUtility.GetRect(120, 22);

            if (UnityEngine.GUI.Button(addRect, "Add"))
            {
                GenericMenu menu = new GenericMenu();

                foreach (Type type in types)
                {
                    menu.AddItem(
                        new GUIContent(type.Name),
                        false,
                        () =>
                        {

                            ElysiumDatabase.AddExtension(type);

                            property.serializedObject.ApplyModifiedProperties();
                            DBPostprocessor.SafetyFixExtensions();
                        });
                }

                menu.ShowAsContext();
            }

            GUILayout.FlexibleSpace();

            EditorGUILayout.EndHorizontal();
        }
        static Texture2D GetClassIcon(Type type)
        {
            if (type == null)
                return null;

            if (_iconCache.TryGetValue(type, out var cachedIcon))
                return cachedIcon;

            string[] guids = AssetDatabase.FindAssets("t:MonoScript");
            
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                MonoScript monoScript = AssetDatabase.LoadAssetAtPath<MonoScript>(path);

                if (monoScript != null && monoScript.GetClass() == type)
                {
                    Texture2D customIcon = EditorGUIUtility.GetIconForObject(monoScript);
                    if (customIcon != null)
                    {
                        _iconCache[type] = customIcon;
                        return customIcon;
                    }
                }
            }

            if (_defaultScriptIcon == null)
            {
                _defaultScriptIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
            }

            _iconCache[type] = _defaultScriptIcon;
            return _defaultScriptIcon;
        }
    }
    public class GroupPathDropdown : AdvancedDropdown
    {
        private readonly SerializedProperty _groupProp;
        private readonly SerializedProperty _property;
        private readonly List<(string path, PropertyGroup group)> _allGroups;

        // Для быстрого поиска пути по id
        private readonly Dictionary<int, string> _idToPath = new Dictionary<int, string>();

        public GroupPathDropdown(AdvancedDropdownState state, SerializedProperty property, SerializedProperty groupProp, 
                               List<(string path, PropertyGroup group)> allGroups) 
            : base(state)
        {
            _property = property;
            _groupProp = groupProp;
            _allGroups = allGroups;
            minimumSize = new UnityEngine.Vector2(300, 350);
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem("Move to Group");

            // None (Root)
            var noneItem = new AdvancedDropdownItem("None (Root)") { id = 0 };
            root.AddChild(noneItem);

            int idCounter = 1;

            foreach (var (path, _) in _allGroups.OrderBy(x => x.path))
            {
                if (string.IsNullOrEmpty(path)) continue;

                AddPathToTree(root, path, ref idCounter);
            }

            return root;
        }

        private void AddPathToTree(AdvancedDropdownItem current, string fullPath, ref int idCounter)
        {
            string[] parts = fullPath.Split('/');
            AdvancedDropdownItem node = current;

            foreach (string part in parts)
            {
                var existing = node.children.FirstOrDefault(c => c.name == part) as AdvancedDropdownItem;

                if (existing == null)
                {
                    existing = new AdvancedDropdownItem(part);
                    node.AddChild(existing);
                }

                node = existing;
            }

            // Присваиваем уникальный id последнему элементу
            node.id = idCounter;
            _idToPath[idCounter] = fullPath;
            idCounter++;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            if (item == null) return;

            string selectedPath = null;

            if (item.id == 0)
            {
                // None (Root)
                _groupProp.stringValue = "";
            }
            else if (_idToPath.TryGetValue(item.id, out selectedPath))
            {
                string currentPath = _groupProp.stringValue;

                if (currentPath == selectedPath)
                {
                    // Уже выбрана эта группа → поднимаемся на уровень выше
                    string[] parts = currentPath.Split('/');
                    if (parts.Length > 1)
                    {
                        var newParts = new List<string>(parts);
                        newParts.RemoveAt(newParts.Count - 1);
                        _groupProp.stringValue = string.Join("/", newParts);
                    }
                    else
                    {
                        _groupProp.stringValue = "";
                    }
                }
                else
                {
                    _groupProp.stringValue = selectedPath;
                }
            }

            _property.serializedObject.ApplyModifiedProperties();
            _property.serializedObject.Update();
        }
    }
}
```

## ./Editor/Internal/Auxilary/IMGUITextFieldPro.cs

```csharp
using UnityEditor;
using UnityEngine;

namespace ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text {
    public class IMGUITextFieldPro
    {
        public string text;

        public int caret;
        public int select;

        public bool hasFocus;
        public string placeholder;

        public Color NormalBackground   = new Color(0.20f, 0.20f, 0.20f);
        public Color FocusedBackground  = new Color(0.23f, 0.23f, 0.26f);
        public Color FocusAccentColor   = new Color(0.35f, 0.60f, 0.95f);

        private readonly string controlName;
        public GUIStyle textStyle = new GUIStyle(EditorStyles.label)
        {
            padding = new RectOffset(0, 0, 0, 0),
            margin = new RectOffset(0, 0, 0, 0)
        };
        public GUIStyle placeholderStyle = new GUIStyle(EditorStyles.label)
        {    
            padding = new RectOffset(0, 0, 0, 0),
            margin = new RectOffset(0, 0, 0, 0),
            normal = { textColor = new Color(1f, 1f, 1f, 0.35f) }
        };

        public bool dragging;

        public bool drawBackground = true;

        public IMGUITextFieldPro(string name, string initial = "", string placeholderText = "", bool drawBackground = true)
        {
            controlName = name;

            text = initial ?? "";
            placeholder = placeholderText ?? "";

            caret = text.Length;
            select = caret;

            this.drawBackground = drawBackground;
        }

        public void DrawStyledBackground(Rect rect, bool hasFocus, float accentWidth = 3f)
        {
            Color bg = hasFocus ? FocusedBackground : NormalBackground;
            EditorGUI.DrawRect(rect, bg);

            // Левая акцентная полоска при фокусе (самый стильный вариант)
            if (hasFocus && accentWidth > 0)
            {
                Rect accentRect = new Rect(rect.x, rect.y, accentWidth, rect.height);
                EditorGUI.DrawRect(accentRect, FocusAccentColor);
            }

            // Опционально: лёгкий highlight сверху для объёма (делает "выпуклее")
            if (hasFocus)
            {
                Color highlight = new Color(1f, 1f, 1f, 0.06f);
                Rect topHighlight = new Rect(rect.x, rect.y, rect.width, 2f);
                EditorGUI.DrawRect(topHighlight, highlight);
            }
        }

        // =========================================================
        // DRAW
        // =========================================================

        public void Focus() {
            GUIUtility.keyboardControl = controlName.GetHashCode();
            hasFocus = true;
            caret = text.Length;
            select = caret;
        }

        public void Draw()
        {
            Rect rect = EditorGUILayout.GetControlRect(false, 20);

            Draw(rect);
        }

        public void Draw(Rect rect)
        {

            hasFocus = GUIUtility.keyboardControl == controlName.GetHashCode();
            ValidateState();

            Event e = Event.current;

            // =====================================================
            // FOCUS
            // =====================================================

            HandleFocus(rect);

            // =====================================================
            // INPUT
            // =====================================================

            if (hasFocus)
            {
                HandleKeyboard(e);
                HandleMouse(rect, e);
            } else {
                if(HasSelection())
                    ClearSelection();
            }

            ValidateState();

            // =====================================================
            // DRAW BACKGROUND
            // =====================================================
            if(drawBackground)
                DrawStyledBackground(rect, hasFocus);

            // =====================================================
            // DRAW SELECTION
            // =====================================================

            DrawSelection(rect);

            // =====================================================
            // DRAW TEXT
            // =====================================================
            
            string shownText = text;

            bool showPlaceholder =
                !hasFocus &&
                string.IsNullOrEmpty(text) &&
                !string.IsNullOrEmpty(placeholder);

            UnityEngine.GUI.Label(
                new Rect(rect.x + 4, rect.y, rect.width - 8, rect.height),
                showPlaceholder ? placeholder : shownText,
                showPlaceholder ? placeholderStyle : textStyle
            );

            // =====================================================
            // DRAW CARET
            // =====================================================

            DrawCaret(rect);

            // =====================================================
            // REPAINT
            // =====================================================

            if (hasFocus)
                UnityEngine.GUI.changed = true;
        }

        // =========================================================
        // FOCUS
        // =========================================================

        void HandleFocus(Rect rect)
        {
            Event e = Event.current;

            if (e.type != EventType.MouseDown)
                return;

            if (rect.Contains(e.mousePosition))
            {
                if(!hasFocus) {
                    caret = GetCharacterIndex(rect, e.mousePosition);
                    select = caret;

                    GUIUtility.keyboardControl = controlName.GetHashCode();
                }
            }
            else if(hasFocus) {
                caret = 0;
                select = 0;

                GUIUtility.keyboardControl = -1;
            }
        }

        // =========================================================
        // KEYBOARD
        // =========================================================

        void HandleKeyboard(Event e)
        {
            if (e.type != EventType.KeyDown)
                return;

            // =====================================================
            // CTRL + A
            // =====================================================

            if (e.control && e.keyCode == KeyCode.A)
            {
                SelectAll();
                e.Use();
                return;
            }

            // =====================================================
            // CTRL + C
            // =====================================================

            if (e.control && e.keyCode == KeyCode.C)
            {
                EditorGUIUtility.systemCopyBuffer = GetSelectedText();

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + X
            // =====================================================

            if (e.control && e.keyCode == KeyCode.X)
            {
                if (HasSelection())
                {
                    EditorGUIUtility.systemCopyBuffer = GetSelectedText();

                    ReplaceSelection("");
                }

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + V
            // =====================================================

            if (e.control && e.keyCode == KeyCode.V)
            {
                ReplaceSelection(
                    EditorGUIUtility.systemCopyBuffer);

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + BACKSPACE
            // =====================================================

            if (e.control && e.keyCode == KeyCode.Backspace)
            {
                DeleteWordBackward();

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + DELETE
            // =====================================================

            if (e.control && e.keyCode == KeyCode.Delete)
            {
                DeleteWordForward();

                e.Use();
                return;
            }

            // =====================================================
            // HOME
            // =====================================================

            if (e.keyCode == KeyCode.Home)
            {
                MoveCaretAbsolute(0, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // END
            // =====================================================

            if (e.keyCode == KeyCode.End)
            {
                MoveCaretAbsolute(text.Length, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + LEFT
            // =====================================================

            if (e.control && e.keyCode == KeyCode.LeftArrow)
            {
                MoveWordLeft(e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + RIGHT
            // =====================================================

            if (e.control && e.keyCode == KeyCode.RightArrow)
            {
                MoveWordRight(e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // LEFT
            // =====================================================

            if (e.keyCode == KeyCode.LeftArrow)
            {
                MoveCaret(-1, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // RIGHT
            // =====================================================

            if (e.keyCode == KeyCode.RightArrow)
            {
                MoveCaret(+1, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // BACKSPACE
            // =====================================================

            if (e.keyCode == KeyCode.Backspace)
            {
                Backspace();

                e.Use();
                return;
            }

            // =====================================================
            // DELETE
            // =====================================================

            if (e.keyCode == KeyCode.Delete)
            {
                Delete();

                e.Use();
                return;
            }

            // =====================================================
            // TEXT INPUT
            // =====================================================

            if (!char.IsControl(e.character))
            {
                ReplaceSelection(e.character.ToString());

                e.Use();
            }
        }

        // =========================================================
        // MOUSE
        // =========================================================

        void HandleMouse(Rect rect, Event e)
        {
            // =====================================================
            // START DRAG
            // =====================================================

            if (rect.Contains(e.mousePosition) && e.type == EventType.MouseDown)
            {
                caret = GetCharacterIndex(rect, e.mousePosition);
                select = caret;

                dragging = true;
            }

            // =====================================================
            // DRAG
            // =====================================================


            if (dragging)
            {
                select = GetCharacterIndex(rect, e.mousePosition);
            }

            // =====================================================
            // END DRAG
            // =====================================================

            if (e.type == EventType.MouseUp)
            {
                dragging = false;
            }
        }

        // =========================================================
        // TEXT OPERATIONS
        // =========================================================

        void ReplaceSelection(string insert)
        {
            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            text = text.Remove(start, end - start);
            text = text.Insert(start, insert);

            caret = start + insert.Length;
            select = caret;
        }

        void Backspace()
        {
            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            // selection delete
            if (start != end)
            {
                text = text.Remove(start, end - start);

                caret = start;
                select = caret;

                return;
            }

            // single char delete
            if (caret > 0)
            {
                text = text.Remove(caret - 1, 1);

                caret--;
                select = caret;
            }
        }

        void Delete()
        {
            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            // selection delete
            if (start != end)
            {
                text = text.Remove(start, end - start);

                caret = start;
                select = caret;

                return;
            }

            // single char delete
            if (caret < text.Length)
            {
                text = text.Remove(caret, 1);

                select = caret;
            }
        }

        // =========================================================
        // CARET
        // =========================================================

        void MoveCaret(int direction, bool keepSelection)
        {
            ValidateState();

            caret = Mathf.Clamp(
                caret + direction,
                0,
                text.Length);

            if (!keepSelection)
                select = caret;
        }

        // =========================================================
        // DRAW CARET
        // =========================================================

        void DrawCaret(Rect rect)
        {
            if (!hasFocus)
                return;

            if (HasSelection())
                return;

            double time = EditorApplication.timeSinceStartup;

            if ((time % 1.0) > 0.5)
                return;

            ValidateState();

            string left = SafeSubstring(text, 0, caret);

            Vector2 size =
            textStyle.CalcSize(
                new GUIContent(left));

            Rect caretRect = new Rect(
                rect.x + 4 + size.x,
                rect.y + 2,
                1,
                rect.height - 4);

            EditorGUI.DrawRect(caretRect, Color.white);
        }

        // =========================================================
        // DRAW SELECTION
        // =========================================================

        void DrawSelection(Rect rect)
        {
            if (!HasSelection())
                return;

            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            string left =
            SafeSubstring(text, 0, start);

            string selected =
            SafeSubstring(text, start, end - start);

            Vector2 leftSize =
            textStyle.CalcSize(
                new GUIContent(left));

            Vector2 selectedSize =
            textStyle.CalcSize(
                new GUIContent(selected));

            Rect selRect = new Rect(
                rect.x + 4 + leftSize.x,
                rect.y + 2,
                selectedSize.x,
                rect.height - 4);

            EditorGUI.DrawRect(
                selRect,
                new Color(0.24f, 0.48f, 0.90f, 0.5f));
        }

        // =========================================================
        // HELPERS
        // =========================================================

        int GetCharacterIndex(Rect rect, Vector2 mouse)
        {
            float x = mouse.x - rect.x - 4;

            for (int i = 0; i <= text.Length; i++)
            {
                string sub = SafeSubstring(text, 0, i);

                float width =
                textStyle.CalcSize(
                    new GUIContent(sub)).x;

                    if (x < width)
                        return i;
            }

            return text.Length;
        }

        void ValidateState()
        {
            text ??= "";

            caret = Mathf.Clamp(caret, 0, text.Length);
            select = Mathf.Clamp(select, 0, text.Length);
        }

        public bool HasSelection()
        {
            return caret != select;
        }

        string SafeSubstring(string str, int start)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            start = Mathf.Clamp(start, 0, str.Length);

            return str.Substring(start);
        }

        string SafeSubstring(string str, int start, int length)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            start = Mathf.Clamp(start, 0, str.Length);

            length = Mathf.Clamp(
                length,
                0,
                str.Length - start);

            return str.Substring(start, length);
        }

        // =========================================================
        // PUBLIC API
        // =========================================================

        public void SetSelection(int start, int end)
        {
            caret = end;
            select = start;

            ValidateState();
        }

        public void SelectAll()
        {
            caret = text.Length;
            select = 0;
        }

        public void ClearSelection()
        {
            select = caret;
        }

        public string GetSelectedText()
        {
            if (!HasSelection())
                return "";

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            return SafeSubstring(text, start, end - start);
        }
        void MoveCaretAbsolute(int position, bool keepSelection)
        {
            caret = Mathf.Clamp(position, 0, text.Length);

            if (!keepSelection)
                select = caret;
        }

        void MoveWordLeft(bool keepSelection)
        {
            ValidateState();

            int pos = caret;

            while (pos > 0 && char.IsWhiteSpace(text[pos - 1]))
                pos--;

            while (pos > 0 && !char.IsWhiteSpace(text[pos - 1]))
                pos--;

            caret = pos;

            if (!keepSelection)
                select = caret;
        }

        void MoveWordRight(bool keepSelection)
        {
            ValidateState();

            int pos = caret;

            while (pos < text.Length && char.IsWhiteSpace(text[pos]))
                pos++;

            while (pos < text.Length && !char.IsWhiteSpace(text[pos]))
                pos++;

            caret = pos;

            if (!keepSelection)
                select = caret;
        }

        void DeleteWordBackward()
        {
            ValidateState();

            if (HasSelection())
            {
                ReplaceSelection("");
                return;
            }

            int start = caret;

            while (start > 0 && char.IsWhiteSpace(text[start - 1]))
                start--;

            while (start > 0 && !char.IsWhiteSpace(text[start - 1]))
                start--;

            text = text.Remove(start, caret - start);

            caret = start;
            select = caret;
        }

        void DeleteWordForward()
        {
            ValidateState();

            if (HasSelection())
            {
                ReplaceSelection("");
                return;
            }

            int end = caret;

            while (end < text.Length && char.IsWhiteSpace(text[end]))
                end++;

            while (end < text.Length && !char.IsWhiteSpace(text[end]))
                end++;

            text = text.Remove(caret, end - caret);

            select = caret;
        }
        void SelectWordAt(int index)
        {
            ValidateState();

            if (text.Length == 0)
            {
                caret = 0;
                select = 0;
                return;
            }

            index = Mathf.Clamp(index, 0, text.Length - 1);

            int start = index;
            int end = index;

            while (start > 0 && !char.IsWhiteSpace(text[start - 1]))
                start--;

            while (end < text.Length && !char.IsWhiteSpace(text[end]))
                end++;

            select = start;
            caret = end;
        }
    }
}
```

## ./Editor/Internal/DBPostprocessor.cs

```csharp
using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Core.Settings;

namespace ModuDevCore.ElysiumDB.Editor.Internal
{
    public class DBPostprocessor : AssetPostprocessor
    {
        private const string RootFolder = "Assets/ElysiumDB";
        private const string ResourcesFolder = "Assets/ElysiumDB/Resources";
        private const string AssetPath = "Assets/ElysiumDB/Resources/ElysiumDB Settings.asset";

        private static bool _isProcessing;

        static void OnPostprocessAllAssets(
            string[] imported,
            string[] deleted,
            string[] moved,
            string[] movedFrom)
        {
            if (_isProcessing)
            
                return;

            if (!IsRelevant(imported, deleted, moved))
                return;

            _isProcessing = true;

            try
            {
                SafetyFix();
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private static bool IsRelevant(
            string[] imported,
            string[] deleted,
            string[] moved)
        {
            return imported.Any(p => p.Contains("ElysiumDB")) ||
                   deleted.Any(p => p.Contains("ElysiumDB")) ||
                   moved.Any(p => p.Contains("ElysiumDB"));
        }

        static void SafetyFix()
        {
            EnsureFolders();

            var settings = FindSettings(out string currentPath);

            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<ElysiumDBSettings>();
                AssetDatabase.CreateAsset(settings, AssetPath);
                AssetDatabase.SaveAssets();
                return;
            }

            if (currentPath != AssetPath)
            {
                string error = AssetDatabase.MoveAsset(currentPath, AssetPath);

                if (!string.IsNullOrEmpty(error))
                {
                    Debug.LogWarning("[ElysiumDB] Move failed: " + error);
                }
            }
            SafetyFixExtensions();
        }

        public static void SafetyFixExtensions() {
            ElysiumDBSettings Settings = ElysiumDatabase.Settings;

            Settings.extensions.RemoveAll(x => x == null);

            ElysiumDatabase.ProcessRequiredExtensions();
            var extensions = Settings.extensions;
			if (extensions == null || extensions.Count == 0) return;

			var frequency = new Dictionary<int, int>();
			foreach (var ext in extensions)
			{
		        int id = ext.extensionId;
		        if (id <= 0)
		            frequency[id] = 99999;
		        else
		            frequency[id] = frequency.TryGetValue(id, out int c) ? c + 1 : 1;
			}

			var safeIds = new HashSet<int>(
			    frequency.Where(kv => kv.Value == 1 && kv.Key > 0)
			             .Select(kv => kv.Key)
			);

			var usedIds = new HashSet<int>(safeIds);

			// === ГЛАВНОЕ ИЗМЕНЕНИЕ ===
			int nextId = 1;
			while (usedIds.Contains(nextId))
			    nextId++;

			foreach (var ext in extensions)
			{
			    if (ext == null) continue;
			    if (safeIds.Contains(ext.extensionId))
			        continue;

			    while (usedIds.Contains(nextId))
			        nextId++;

			    ext.extensionId = nextId;
			    usedIds.Add(nextId);
			    nextId++;
			}
        }

        static void EnsureFolders()
        {
            if (!AssetDatabase.IsValidFolder(RootFolder))
                AssetDatabase.CreateFolder("Assets", "ElysiumDB");

            if (!AssetDatabase.IsValidFolder(ResourcesFolder))
                AssetDatabase.CreateFolder(RootFolder, "Resources");
        }

        static ElysiumDBSettings FindSettings(out string path)
        {
            path = null;

            string[] guids =
                AssetDatabase.FindAssets("t:ElysiumDBSettings");

            foreach (var guid in guids)
            {
                string p = AssetDatabase.GUIDToAssetPath(guid);

                if (string.IsNullOrEmpty(p))
                    continue;

                var asset =
                    AssetDatabase.LoadAssetAtPath<ElysiumDBSettings>(p);

                if (asset == null)
                    continue;

                path = p;
                return asset;
            }

            return null;
        }
    }
}
```

## ./Extensions/AuthExtension/AuthElysiumDB.cs

```csharp
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class AuthElysiumDB : DBExtensionBase
{
    public string cacheFileName = "elysium_session.cache";
    public bool IsAuthenticated { get; private set; }

    private IAuthElysiumReceiver[] _receivers => GetExtensions<IAuthElysiumReceiver>();

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Debug.Log("AuthElysiumDB initialized");
    }

    protected override void OnDispose()
    {
    }

    public void Auth(string сredentials) {
        PlayerPrefs.SetString(cacheFileName, сredentials);
        NotifyAuthTokenUpdated(сredentials);
    }
    public void SignOut() {
        PlayerPrefs.DeleteKey(cacheFileName);
    }
    public string GetCredentials() {
        return PlayerPrefs.GetString(cacheFileName);
    }

    void NotifyAuthTokenUpdated(string newJwt) {
        foreach(IAuthElysiumReceiver iaer in _receivers)
            iaer.OnAuthTokenUpdated(newJwt);
    }
}
```

## ./Extensions/AuthExtension/AuthElysiumDBDrawer.cs

```csharp
using UnityEngine;
using UnityEditor;
using ModuDevCore.ElysiumDB;

[CustomPropertyDrawer(typeof(AuthElysiumDB))]
public class AuthElysiumDBDrawer : PropertyDrawer
{
    bool showCredentials = false;
    public float height = 0;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        height = 0;
        EditorGUI.BeginProperty(position, label, property);

        float y = position.y;

        // Получаем экземпляр AuthElysiumDB
        AuthElysiumDB auth = null;
        if (ElysiumDatabase.Instance != null)
        {
            auth = ElysiumDatabase.GetExtension<AuthElysiumDB>();
        }

        if (auth == null)
        {
            Rect errorRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(errorRect, "Cannot access AuthElysiumDB (ElysiumDatabase.Instance is null)", EditorStyles.helpBox);
            EditorGUI.EndProperty();
            return;
        }

        EditorGUI.indentLevel++;

        // === Наша информация ===
        Rect rect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.LabelField(rect, "Is Authenticated", auth.IsAuthenticated ? "✅ Yes" : "❌ No");
        rect.y += EditorGUIUtility.singleLineHeight + 2;
        
        Rect foldoutRect = new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
        showCredentials = EditorGUI.Foldout(foldoutRect, showCredentials, "Credentials", true);
        
        rect.y += EditorGUIUtility.singleLineHeight + 2;
        height += EditorGUIUtility.singleLineHeight + 2;

        if (showCredentials)
        {
            string credentials = string.IsNullOrEmpty(auth.GetCredentials()) 
                ? "— None —" 
                : auth.GetCredentials();

            rect.height = EditorStyles.textArea.CalcHeight(new GUIContent(credentials), rect.width);
            rect.height += EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(rect, credentials, EditorStyles.textArea);
            rect.y += rect.height;
            height += rect.height;
        }

        // Кнопки
        rect.y += 4;
        rect.height = 22;

        if (GUI.Button(new Rect(rect.x, rect.y, 110, 22), "Refresh"))
        {
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        }

        if (GUI.Button(new Rect(rect.x + 120, rect.y, 140, 22), "Clear Session"))
        {
            if (EditorUtility.DisplayDialog("Clear Auth Session", 
                    "Are you sure you want to clear the session?", "Yes", "Cancel"))
            {
                PlayerPrefs.DeleteKey("ElysiumSession");
                auth.Auth("");
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
        }

        EditorGUI.indentLevel--;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float totalHeight = EditorGUIUtility.singleLineHeight;

        // Получаем высоту всех children (внутренних полей)
        SerializedProperty iterator = property.Copy();
        bool enterChildren = true;
        bool isFirst = true;

        while (iterator.NextVisible(enterChildren))
        {
            if (isFirst)
            {
                isFirst = false;
                enterChildren = false;
                continue; // Пропускаем сам корневой property
            }

            if (iterator.name == "m_Script")
                continue;

            totalHeight += EditorGUI.GetPropertyHeight(iterator, null, true) + 2;
        }

        return totalHeight + height;
    }
}
```

## ./Extensions/AuthExtension/IAuthElysiumReceiver.cs

```csharp
using Newtonsoft.Json.Linq;

public interface IAuthElysiumReceiver
{
    public void OnAuthTokenUpdated(string newJwt);

    public void OnAuthLoggedOut();
}
```

## ./Internal/Data/ExtensionEvent.cs

```csharp
namespace ModuDevCore.ElysiumDB.Internal.Data{
	public enum ExtensionEvent {
		Initialize = 0,
		Dispose = 1
	}
}
```

