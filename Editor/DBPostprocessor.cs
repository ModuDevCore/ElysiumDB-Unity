using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Core.Settings;

namespace ModuDevCore.ElysiumDB.Editor 
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

            ElysiumDatabase.ProcessRequiredExtensions();
            var extensions = Settings.extensions;
			if (extensions == null || extensions.Count == 0) return;

			var frequency = new Dictionary<int, int>();
			foreach (var ext in extensions)
			{
			    if (ext != null)
			    {
			        int id = ext.extensionId;
			        if (id <= 0)
			            frequency[id] = 99999;
			        else
			            frequency[id] = frequency.TryGetValue(id, out int c) ? c + 1 : 1;
			    }
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