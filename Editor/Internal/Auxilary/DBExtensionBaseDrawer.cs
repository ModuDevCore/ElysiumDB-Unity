using UnityEngine;
using UnityEditor;
using ModuDevCore.ElysiumDB.Extension;
using ModuDevCore.ElysiumDB.Editor.Internal.GUI.List;

namespace ModuDevCore.ElysiumDB.Editor.Internal {
    [CustomPropertyDrawer(typeof(DBExtensionBase), true)]
    public class DBExtensionBaseDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            bool isArrayElement = property.propertyPath.Contains(".Array.data[");

            if (isArrayElement)
            {
                DrawChildrenWithoutHeader(position, property);
            }
            else
            {
                EditorGUI.PropertyField(position, property, label, true);
            }

            EditorGUI.EndProperty();
        }

        private void DrawChildrenWithoutHeader(Rect position, SerializedProperty property)
        {
            // Сбрасываем отступы
            EditorGUI.indentLevel++;

            SerializedProperty iterator = property.Copy();
            SerializedProperty end = property.GetEndProperty();

            // Пропускаем сам корневой property (чтобы не рисовался header)
            bool enterChildren = true;
            while (iterator.NextVisible(enterChildren))
            {
                if (SerializedProperty.EqualContents(iterator, end))
                    break;

                position.height = EditorGUI.GetPropertyHeight(iterator, iterator.isExpanded);
                EditorGUI.PropertyField(position, iterator, true);

                position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
                enterChildren = false;
            }

            EditorGUI.indentLevel--;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            bool isArrayElement = property.propertyPath.Contains(".Array.data[");

            if (isArrayElement)
            {
                return GetChildrenHeight(property);
            }
            else
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
        }

        private float GetChildrenHeight(SerializedProperty property)
        {
            float totalHeight = 0f;
            SerializedProperty iterator = property.Copy();
            SerializedProperty end = property.GetEndProperty();

            bool enterChildren = true;
            while (iterator.NextVisible(enterChildren))
            {
                if (SerializedProperty.EqualContents(iterator, end))
                    break;

                totalHeight += EditorGUI.GetPropertyHeight(iterator, iterator.isExpanded) 
                               + EditorGUIUtility.standardVerticalSpacing;
                enterChildren = false;
            }

            return totalHeight - EditorGUIUtility.standardVerticalSpacing;
        }
    }
}