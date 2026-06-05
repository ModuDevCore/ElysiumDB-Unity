using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

using UnityEditor;
using UnityEngine;

using ModuDevCore.ElysiumDB.Extension;
using ModuDevCore.ElysiumDB.Editor.Internal;
using ModuDevCore.ElysiumDB.Editor.GUI.List;

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