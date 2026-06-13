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