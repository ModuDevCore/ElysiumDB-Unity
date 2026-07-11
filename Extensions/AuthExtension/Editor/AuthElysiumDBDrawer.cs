#if UNITY_EDITOR
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
#endif