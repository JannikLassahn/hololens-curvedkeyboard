using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

namespace HoloLensKeyboard
{
    /// <summary>
    /// Represents a single key of the keyboard.
    /// </summary>
    public class KeyboardItem : MonoBehaviour, IInputHandler, IFocusable
    {
        private int index;
        private bool iSelected;
        private Text key;
        private ColorTheme theme;
        private Renderer r;

        #region IInputClickHandler and IFocusable member

        public void OnFocusEnter()
        {
            r.material = theme.GetThemeValue(KeyState.Focused);
        }

        public void OnFocusExit()
        {
            r.material = theme.GetThemeValue(KeyState.Default);
        }

        public void OnInputDown(InputEventData eventData)
        {
            r.material = theme.GetThemeValue(KeyState.Pressed);
            iSelected = true;
        }

        public void OnInputUp(InputEventData eventData)
        {
            r.material = theme.GetThemeValue(KeyState.Focused);

            if (iSelected)
            {
                KeyboardCreator.Instance.HandleTap(this);
                iSelected = false;
            }
        }

        #endregion

        protected virtual void Awake()
        {
            if(r == null || key == null)
            {
                r = GetComponentInChildren<Renderer>();
                key = GetComponentInChildren<Text>();
            }
        }

        /// <summary>
        /// Initializes the key.
        /// </summary>
        /// <param name="index">The letter index.</param>
        /// <param name="theme">The current theme.</param>
        /// <param name="set">The initial set of letters to use.</param>
        public void Initialize(int index, ColorTheme theme, KeySet set)
        {
            Awake();

            this.index = index;
            this.theme = theme;

            SetKeyText(set);
            r.material = theme.GetThemeValue(KeyState.Default);
        }

        /// <summary>
        /// Sets the text of this key.
        /// </summary>
        /// <param name="set">The type.</param>
        public void SetKeyText(KeySet set)
        {
            string value = "";
            switch (set)
            {
                case KeySet.LowerCase:
                    value = Keys.LowerCase[index];
                    break;
                case KeySet.UpperCase:
                    value = Keys.UpperCase[index];
                    break;
                case KeySet.Special:
                    value = Keys.Specials[index];
                    break;
            }
            key.text = value;
        }

        /// <summary>
        /// Gets the index of this key.
        /// </summary>
        public int Index
        {
            get { return index; }
        }

        /// <summary>
        /// Gets the current letter.
        /// </summary>
        public string Value
        {
            get { return key.text; }
        }
    }
}

