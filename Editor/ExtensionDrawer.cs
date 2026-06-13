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