using UnityEngine;
using UnityEditor;
using ModuDevCore.ElysiumDB;

[CustomPropertyDrawer(typeof(AuthElysiumDB))]
public class AuthElysiumDBDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        float y = position.y;

        // Получаем экземпляр AuthElysiumDB
        AuthElysiumDB auth = null;
        if (ElysiumDatabase.Instance != null)
        {
            auth = ElysiumDatabase.Instance.GetExtension<AuthElysiumDB>();
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

        string jwt = auth.GetJWT();
        string jwtShort = string.IsNullOrEmpty(jwt) 
            ? "— None —" 
            : (jwt.Length > 40 ? jwt.Substring(0, 37) + "..." : jwt);

        EditorGUI.LabelField(rect, "JWT Token", jwtShort);
        rect.y += EditorGUIUtility.singleLineHeight + 2;

        if (!string.IsNullOrEmpty(jwt))
        {
            EditorGUI.LabelField(rect, "Token Length", $"{jwt.Length} characters");
            rect.y += EditorGUIUtility.singleLineHeight + 4;
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
        totalHeight += 8;

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

        // Добавляем высоту нашей кастомной информации
        totalHeight += EditorGUIUtility.singleLineHeight * 4;  

        return totalHeight;
    }
}