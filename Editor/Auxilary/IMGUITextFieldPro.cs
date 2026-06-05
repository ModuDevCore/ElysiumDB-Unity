using UnityEditor;
using UnityEngine;

namespace ModuDevCore.ElysiumDB.Editor.GUI.Text {
    public class IMGUITextFieldPro
    {
        public string text;

        public int caret;
        public int select;

        public bool hasFocus;
        public string placeholder;

        public Color NormalBackground   = new Color(0.20f, 0.20f, 0.20f);
        public Color FocusedBackground  = new Color(0.23f, 0.23f, 0.26f);
        public Color FocusAccentColor   = new Color(0.35f, 0.60f, 0.95f);

        private readonly string controlName;
        public GUIStyle textStyle = new GUIStyle(EditorStyles.label)
        {
            padding = new RectOffset(0, 0, 0, 0),
            margin = new RectOffset(0, 0, 0, 0)
        };
        public GUIStyle placeholderStyle = new GUIStyle(EditorStyles.label)
        {    
            padding = new RectOffset(0, 0, 0, 0),
            margin = new RectOffset(0, 0, 0, 0),
            normal = { textColor = new Color(1f, 1f, 1f, 0.35f) }
        };

        public bool dragging;

        public bool drawBackground = true;

        public IMGUITextFieldPro(string name, string initial = "", string placeholderText = "", bool drawBackground = true)
        {
            controlName = name;

            text = initial ?? "";
            placeholder = placeholderText ?? "";

            caret = text.Length;
            select = caret;

            this.drawBackground = drawBackground;
        }

        public void DrawStyledBackground(Rect rect, bool hasFocus, float accentWidth = 3f)
        {
            Color bg = hasFocus ? FocusedBackground : NormalBackground;
            EditorGUI.DrawRect(rect, bg);

            // Левая акцентная полоска при фокусе (самый стильный вариант)
            if (hasFocus && accentWidth > 0)
            {
                Rect accentRect = new Rect(rect.x, rect.y, accentWidth, rect.height);
                EditorGUI.DrawRect(accentRect, FocusAccentColor);
            }

            // Опционально: лёгкий highlight сверху для объёма (делает "выпуклее")
            if (hasFocus)
            {
                Color highlight = new Color(1f, 1f, 1f, 0.06f);
                Rect topHighlight = new Rect(rect.x, rect.y, rect.width, 2f);
                EditorGUI.DrawRect(topHighlight, highlight);
            }
        }

        // =========================================================
        // DRAW
        // =========================================================

        public void Focus() {
            GUIUtility.keyboardControl = controlName.GetHashCode();
            hasFocus = true;
            caret = text.Length;
            select = caret;
        }

        public void Draw()
        {
            Rect rect = EditorGUILayout.GetControlRect(false, 20);

            Draw(rect);
        }

        public void Draw(Rect rect)
        {

            hasFocus = GUIUtility.keyboardControl == controlName.GetHashCode();
            ValidateState();

            Event e = Event.current;

            // =====================================================
            // FOCUS
            // =====================================================

            HandleFocus(rect);

            // =====================================================
            // INPUT
            // =====================================================

            if (hasFocus)
            {
                HandleKeyboard(e);
                HandleMouse(rect, e);
            } else {
                if(HasSelection())
                    ClearSelection();
            }

            ValidateState();

            // =====================================================
            // DRAW BACKGROUND
            // =====================================================
            if(drawBackground)
                DrawStyledBackground(rect, hasFocus);

            // =====================================================
            // DRAW SELECTION
            // =====================================================

            DrawSelection(rect);

            // =====================================================
            // DRAW TEXT
            // =====================================================
            
            string shownText = text;

            bool showPlaceholder =
                !hasFocus &&
                string.IsNullOrEmpty(text) &&
                !string.IsNullOrEmpty(placeholder);

            UnityEngine.GUI.Label(
                new Rect(rect.x + 4, rect.y, rect.width - 8, rect.height),
                showPlaceholder ? placeholder : shownText,
                showPlaceholder ? placeholderStyle : textStyle
            );

            // =====================================================
            // DRAW CARET
            // =====================================================

            DrawCaret(rect);

            // =====================================================
            // REPAINT
            // =====================================================

            if (hasFocus)
                UnityEngine.GUI.changed = true;
        }

        // =========================================================
        // FOCUS
        // =========================================================

        void HandleFocus(Rect rect)
        {
            Event e = Event.current;

            if (e.type != EventType.MouseDown)
                return;

            if (rect.Contains(e.mousePosition))
            {
                if(!hasFocus) {
                    caret = GetCharacterIndex(rect, e.mousePosition);
                    select = caret;

                    GUIUtility.keyboardControl = controlName.GetHashCode();
                }
            }
            else if(hasFocus) {
                caret = 0;
                select = 0;

                GUIUtility.keyboardControl = -1;
            }
        }

        // =========================================================
        // KEYBOARD
        // =========================================================

        void HandleKeyboard(Event e)
        {
            if (e.type != EventType.KeyDown)
                return;

            // =====================================================
            // CTRL + A
            // =====================================================

            if (e.control && e.keyCode == KeyCode.A)
            {
                SelectAll();
                e.Use();
                return;
            }

            // =====================================================
            // CTRL + C
            // =====================================================

            if (e.control && e.keyCode == KeyCode.C)
            {
                EditorGUIUtility.systemCopyBuffer = GetSelectedText();

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + X
            // =====================================================

            if (e.control && e.keyCode == KeyCode.X)
            {
                if (HasSelection())
                {
                    EditorGUIUtility.systemCopyBuffer = GetSelectedText();

                    ReplaceSelection("");
                }

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + V
            // =====================================================

            if (e.control && e.keyCode == KeyCode.V)
            {
                ReplaceSelection(
                    EditorGUIUtility.systemCopyBuffer);

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + BACKSPACE
            // =====================================================

            if (e.control && e.keyCode == KeyCode.Backspace)
            {
                DeleteWordBackward();

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + DELETE
            // =====================================================

            if (e.control && e.keyCode == KeyCode.Delete)
            {
                DeleteWordForward();

                e.Use();
                return;
            }

            // =====================================================
            // HOME
            // =====================================================

            if (e.keyCode == KeyCode.Home)
            {
                MoveCaretAbsolute(0, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // END
            // =====================================================

            if (e.keyCode == KeyCode.End)
            {
                MoveCaretAbsolute(text.Length, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + LEFT
            // =====================================================

            if (e.control && e.keyCode == KeyCode.LeftArrow)
            {
                MoveWordLeft(e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // CTRL + RIGHT
            // =====================================================

            if (e.control && e.keyCode == KeyCode.RightArrow)
            {
                MoveWordRight(e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // LEFT
            // =====================================================

            if (e.keyCode == KeyCode.LeftArrow)
            {
                MoveCaret(-1, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // RIGHT
            // =====================================================

            if (e.keyCode == KeyCode.RightArrow)
            {
                MoveCaret(+1, e.shift);

                e.Use();
                return;
            }

            // =====================================================
            // BACKSPACE
            // =====================================================

            if (e.keyCode == KeyCode.Backspace)
            {
                Backspace();

                e.Use();
                return;
            }

            // =====================================================
            // DELETE
            // =====================================================

            if (e.keyCode == KeyCode.Delete)
            {
                Delete();

                e.Use();
                return;
            }

            // =====================================================
            // TEXT INPUT
            // =====================================================

            if (!char.IsControl(e.character))
            {
                ReplaceSelection(e.character.ToString());

                e.Use();
            }
        }

        // =========================================================
        // MOUSE
        // =========================================================

        void HandleMouse(Rect rect, Event e)
        {
            // =====================================================
            // START DRAG
            // =====================================================

            if (rect.Contains(e.mousePosition) && e.type == EventType.MouseDown)
            {
                caret = GetCharacterIndex(rect, e.mousePosition);
                select = caret;

                dragging = true;
            }

            // =====================================================
            // DRAG
            // =====================================================


            if (dragging)
            {
                select = GetCharacterIndex(rect, e.mousePosition);
            }

            // =====================================================
            // END DRAG
            // =====================================================

            if (e.type == EventType.MouseUp)
            {
                dragging = false;
            }
        }

        // =========================================================
        // TEXT OPERATIONS
        // =========================================================

        void ReplaceSelection(string insert)
        {
            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            text = text.Remove(start, end - start);
            text = text.Insert(start, insert);

            caret = start + insert.Length;
            select = caret;
        }

        void Backspace()
        {
            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            // selection delete
            if (start != end)
            {
                text = text.Remove(start, end - start);

                caret = start;
                select = caret;

                return;
            }

            // single char delete
            if (caret > 0)
            {
                text = text.Remove(caret - 1, 1);

                caret--;
                select = caret;
            }
        }

        void Delete()
        {
            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            // selection delete
            if (start != end)
            {
                text = text.Remove(start, end - start);

                caret = start;
                select = caret;

                return;
            }

            // single char delete
            if (caret < text.Length)
            {
                text = text.Remove(caret, 1);

                select = caret;
            }
        }

        // =========================================================
        // CARET
        // =========================================================

        void MoveCaret(int direction, bool keepSelection)
        {
            ValidateState();

            caret = Mathf.Clamp(
                caret + direction,
                0,
                text.Length);

            if (!keepSelection)
                select = caret;
        }

        // =========================================================
        // DRAW CARET
        // =========================================================

        void DrawCaret(Rect rect)
        {
            if (!hasFocus)
                return;

            if (HasSelection())
                return;

            double time = EditorApplication.timeSinceStartup;

            if ((time % 1.0) > 0.5)
                return;

            ValidateState();

            string left = SafeSubstring(text, 0, caret);

            Vector2 size =
            textStyle.CalcSize(
                new GUIContent(left));

            Rect caretRect = new Rect(
                rect.x + 4 + size.x,
                rect.y + 2,
                1,
                rect.height - 4);

            EditorGUI.DrawRect(caretRect, Color.white);
        }

        // =========================================================
        // DRAW SELECTION
        // =========================================================

        void DrawSelection(Rect rect)
        {
            if (!HasSelection())
                return;

            ValidateState();

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            string left =
            SafeSubstring(text, 0, start);

            string selected =
            SafeSubstring(text, start, end - start);

            Vector2 leftSize =
            textStyle.CalcSize(
                new GUIContent(left));

            Vector2 selectedSize =
            textStyle.CalcSize(
                new GUIContent(selected));

            Rect selRect = new Rect(
                rect.x + 4 + leftSize.x,
                rect.y + 2,
                selectedSize.x,
                rect.height - 4);

            EditorGUI.DrawRect(
                selRect,
                new Color(0.24f, 0.48f, 0.90f, 0.5f));
        }

        // =========================================================
        // HELPERS
        // =========================================================

        int GetCharacterIndex(Rect rect, Vector2 mouse)
        {
            float x = mouse.x - rect.x - 4;

            for (int i = 0; i <= text.Length; i++)
            {
                string sub = SafeSubstring(text, 0, i);

                float width =
                textStyle.CalcSize(
                    new GUIContent(sub)).x;

                    if (x < width)
                        return i;
            }

            return text.Length;
        }

        void ValidateState()
        {
            text ??= "";

            caret = Mathf.Clamp(caret, 0, text.Length);
            select = Mathf.Clamp(select, 0, text.Length);
        }

        public bool HasSelection()
        {
            return caret != select;
        }

        string SafeSubstring(string str, int start)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            start = Mathf.Clamp(start, 0, str.Length);

            return str.Substring(start);
        }

        string SafeSubstring(string str, int start, int length)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            start = Mathf.Clamp(start, 0, str.Length);

            length = Mathf.Clamp(
                length,
                0,
                str.Length - start);

            return str.Substring(start, length);
        }

        // =========================================================
        // PUBLIC API
        // =========================================================

        public void SetSelection(int start, int end)
        {
            caret = end;
            select = start;

            ValidateState();
        }

        public void SelectAll()
        {
            caret = text.Length;
            select = 0;
        }

        public void ClearSelection()
        {
            select = caret;
        }

        public string GetSelectedText()
        {
            if (!HasSelection())
                return "";

            int start = Mathf.Min(caret, select);
            int end = Mathf.Max(caret, select);

            return SafeSubstring(text, start, end - start);
        }
        void MoveCaretAbsolute(int position, bool keepSelection)
        {
            caret = Mathf.Clamp(position, 0, text.Length);

            if (!keepSelection)
                select = caret;
        }

        void MoveWordLeft(bool keepSelection)
        {
            ValidateState();

            int pos = caret;

            while (pos > 0 && char.IsWhiteSpace(text[pos - 1]))
                pos--;

            while (pos > 0 && !char.IsWhiteSpace(text[pos - 1]))
                pos--;

            caret = pos;

            if (!keepSelection)
                select = caret;
        }

        void MoveWordRight(bool keepSelection)
        {
            ValidateState();

            int pos = caret;

            while (pos < text.Length && char.IsWhiteSpace(text[pos]))
                pos++;

            while (pos < text.Length && !char.IsWhiteSpace(text[pos]))
                pos++;

            caret = pos;

            if (!keepSelection)
                select = caret;
        }

        void DeleteWordBackward()
        {
            ValidateState();

            if (HasSelection())
            {
                ReplaceSelection("");
                return;
            }

            int start = caret;

            while (start > 0 && char.IsWhiteSpace(text[start - 1]))
                start--;

            while (start > 0 && !char.IsWhiteSpace(text[start - 1]))
                start--;

            text = text.Remove(start, caret - start);

            caret = start;
            select = caret;
        }

        void DeleteWordForward()
        {
            ValidateState();

            if (HasSelection())
            {
                ReplaceSelection("");
                return;
            }

            int end = caret;

            while (end < text.Length && char.IsWhiteSpace(text[end]))
                end++;

            while (end < text.Length && !char.IsWhiteSpace(text[end]))
                end++;

            text = text.Remove(caret, end - caret);

            select = caret;
        }
        void SelectWordAt(int index)
        {
            ValidateState();

            if (text.Length == 0)
            {
                caret = 0;
                select = 0;
                return;
            }

            index = Mathf.Clamp(index, 0, text.Length - 1);

            int start = index;
            int end = index;

            while (start > 0 && !char.IsWhiteSpace(text[start - 1]))
                start--;

            while (end < text.Length && !char.IsWhiteSpace(text[end]))
                end++;

            select = start;
            caret = end;
        }
    }
}