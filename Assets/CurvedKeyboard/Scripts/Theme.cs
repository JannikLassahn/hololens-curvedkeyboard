using UnityEngine;

namespace HoloLensKeyboard
{
    /// <summary>
    /// Generic base theme for buttons.
    /// </summary>
    /// <remarks>
    /// Based on HoloToolkit-Examples/Prototyping.
    /// </remarks>
    public class Theme<Type> : MonoBehaviour
    {
        [Tooltip("Tag to help distinguish themes")]
        public string Tag = "default";

        [Tooltip("Default key state")]
        public Type Default;
        [Tooltip("Focus key state")]
        public Type Focused;
        [Tooltip("Pressed key state")]
        public Type Pressed;
        [Tooltip("Selected key state")]
        public Type Selected;
        [Tooltip("Current value : read only")]
        public Type CurrentValue;

        public Type GetThemeValue(KeyState state)
        {
            switch (state)
            {
                case KeyState.Default:
                    CurrentValue = Default;
                    break;
                case KeyState.Focused:
                    CurrentValue = Focused;
                    break;
                case KeyState.Pressed:
                    CurrentValue = Pressed;
                    break;
                case KeyState.Selected:
                    CurrentValue = Selected;
                    break;
                default:
                    CurrentValue = Default;
                    break;
            }

            return CurrentValue;
        }
    }
}

