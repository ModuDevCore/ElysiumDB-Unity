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
	    {
	        var ext = Settings.extensions.OfType<T>().FirstOrDefault();
	        if (ext == null)
	        {
	            Debug.LogWarning($"[ElysiumDB] Extension {typeof(T).Name} not found.");
	        }
	        return ext;
	    }

	    public static T[] GetExtensions<T>() where T : class
	    {
	        var extensions = Settings.extensions.OfType<T>().ToArray();

	        if (extensions.Length == 0)
	        {
	            Debug.LogWarning($"[ElysiumDB] Extensions of type {typeof(T).Name} not found.");
	        }

	        return extensions;
	    }

	    public static bool HasExtension<T>() where T : class
	    {
	        return Settings.extensions.OfType<T>().Any();
	    }

	    public static bool TryGetExtension<T>(out T extension) where T : class
	    {
	        extension = Settings.extensions.OfType<T>().FirstOrDefault();
	        return extension != null;
	    }

		public static T AddExtension<T>() where T : DBExtensionBase, new()
		{
		    if (TryGetExtension<T>(out T existing))
		        return existing;

		    var extension = new T();


		    Settings.extensions.Add(extension);

		    ElysiumDatabase context = Instance;
		    if(context != null)
		    	context.SafeProcess(extension, ExtensionEvent.Initialize);

		    if (!Settings.extensions.Any(e => e?.GetType() == typeof(T)))
		    {
		        EditorUtility.SetDirty(Settings);
		    }

		    Debug.Log($"[ElysiumDB] Extension added: {typeof(T).Name}");

		    return extension;
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