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