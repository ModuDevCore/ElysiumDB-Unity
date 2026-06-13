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