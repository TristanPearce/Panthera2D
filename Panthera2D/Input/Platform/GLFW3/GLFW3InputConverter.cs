using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Panthera2D.Native.Glfw3;

namespace Panthera2D.Input.GLFW3
{
    public class GLFW3InputConverter
    {

        private Dictionary<int, Key> _keyLookup = new Dictionary<int, Key>()
        {
            { GLFW_KEY_UNKNOWN, Key.Unknown},
            { GLFW_KEY_A, Key.A},
            { GLFW_KEY_B, Key.B},
            { GLFW_KEY_C, Key.C},
            { GLFW_KEY_D, Key.D},
            { GLFW_KEY_E, Key.E},
            { GLFW_KEY_F, Key.F},
            { GLFW_KEY_G, Key.G},
            { GLFW_KEY_H, Key.H},
            { GLFW_KEY_I, Key.I},
            { GLFW_KEY_J, Key.J},
            { GLFW_KEY_K, Key.K},
            { GLFW_KEY_L, Key.L},
            { GLFW_KEY_M, Key.M},
            { GLFW_KEY_N, Key.N},
            { GLFW_KEY_O, Key.O},
            { GLFW_KEY_P, Key.P},
            { GLFW_KEY_Q, Key.Q},
            { GLFW_KEY_R, Key.R},
            { GLFW_KEY_S, Key.S},
            { GLFW_KEY_T, Key.T},
            { GLFW_KEY_U, Key.U},
            { GLFW_KEY_V, Key.V},
            { GLFW_KEY_W, Key.W},
            { GLFW_KEY_X, Key.X},
            { GLFW_KEY_Y, Key.Y},
            { GLFW_KEY_Z, Key.Z},
            { GLFW_KEY_0, Key.N0},
            { GLFW_KEY_1, Key.N1},
            { GLFW_KEY_2, Key.N2},
            { GLFW_KEY_3, Key.N3},
            { GLFW_KEY_4, Key.N4},
            { GLFW_KEY_5, Key.N5},
            { GLFW_KEY_6, Key.N6},
            { GLFW_KEY_7, Key.N7},
            { GLFW_KEY_8, Key.N8},
            { GLFW_KEY_9, Key.N9},
            { GLFW_KEY_MINUS, Key.Minus},
            { GLFW_KEY_EQUAL, Key.Equals},
            { GLFW_KEY_KP_0, Key.Numpad0},
            { GLFW_KEY_KP_1, Key.Numpad1},
            { GLFW_KEY_KP_2, Key.Numpad2},
            { GLFW_KEY_KP_3, Key.Numpad3},
            { GLFW_KEY_KP_4, Key.Numpad4},
            { GLFW_KEY_KP_5, Key.Numpad5},
            { GLFW_KEY_KP_6, Key.Numpad6},
            { GLFW_KEY_KP_7, Key.Numpad7},
            { GLFW_KEY_KP_8, Key.Numpad8},
            { GLFW_KEY_KP_9, Key.Numpad9},
            { GLFW_KEY_KP_ADD, Key.NumpadPlus},
            { GLFW_KEY_KP_SUBTRACT, Key.NumpadMinus},
            { GLFW_KEY_KP_MULTIPLY, Key.NumpadMultiply},
            { GLFW_KEY_KP_DIVIDE, Key.NumpadDivide},
            { GLFW_KEY_KP_ENTER, Key.NumpadEnter},
            { GLFW_KEY_KP_DECIMAL, Key.NumpadDecimal},
            { GLFW_KEY_F1, Key.F1},
            { GLFW_KEY_F2, Key.F2},
            { GLFW_KEY_F3, Key.F3},
            { GLFW_KEY_F4, Key.F4},
            { GLFW_KEY_F5, Key.F5},
            { GLFW_KEY_F6, Key.F6},
            { GLFW_KEY_F7, Key.F7},
            { GLFW_KEY_F8, Key.F8},
            { GLFW_KEY_F9, Key.F9},
            { GLFW_KEY_F10, Key.F10},
            { GLFW_KEY_F11, Key.F11},
            { GLFW_KEY_F12, Key.F12},
            { GLFW_KEY_F13, Key.F13},
            { GLFW_KEY_F14, Key.F14},
            { GLFW_KEY_F15, Key.F15},
            { GLFW_KEY_F16, Key.F16},
            { GLFW_KEY_F17, Key.F17},
            { GLFW_KEY_F18, Key.F18},
            { GLFW_KEY_F19, Key.F19},
            { GLFW_KEY_F20, Key.F20},
            { GLFW_KEY_F21, Key.F21},
            { GLFW_KEY_F22, Key.F22},
            { GLFW_KEY_F23, Key.F23},
            { GLFW_KEY_F24, Key.F24},
            { GLFW_KEY_UP, Key.Up},
            { GLFW_KEY_DOWN, Key.Down},
            { GLFW_KEY_LEFT, Key.Left},
            { GLFW_KEY_RIGHT, Key.Right},
            { GLFW_KEY_LEFT_BRACKET, Key.OpenSquareBracket},
            { GLFW_KEY_RIGHT_BRACKET, Key.CloseSquareBracket},
            { GLFW_KEY_SLASH, Key.ForwardSlash},
            { GLFW_KEY_SEMICOLON, Key.SemiColon},
            { GLFW_KEY_PERIOD, Key.Period},
            { GLFW_KEY_COMMA, Key.Comma},
            { GLFW_KEY_APOSTROPHE, Key.SingleQuote},
            //{GLFW_KEY_DoubleQuote, Key.DoubleQuote},
            //{GLFW_KEY_Pound, Key.Pound},
            { GLFW_KEY_SPACE, Key.Space},
            { GLFW_KEY_ESCAPE, Key.Escape},
            { GLFW_KEY_TAB, Key.Tab},
            { GLFW_KEY_CAPS_LOCK, Key.CapsLock},
            //{GLFW_KEY_Tilde, Key.Tilde},
            { GLFW_KEY_LEFT_CONTROL, Key.LeftControl},
            { GLFW_KEY_LEFT_SHIFT, Key.LeftShift},
            { GLFW_KEY_LEFT_ALT, Key.LeftAlt},
            { GLFW_KEY_LEFT_SUPER, Key.LeftWindows},
            { GLFW_KEY_RIGHT_CONTROL, Key.RightControl},
            { GLFW_KEY_RIGHT_SHIFT, Key.RightShift},
            { GLFW_KEY_RIGHT_ALT, Key.RightAlt},
            { GLFW_KEY_PRINT_SCREEN, Key.PrintScreen},
            { GLFW_KEY_INSERT, Key.Insert},
            { GLFW_KEY_DELETE, Key.Delete},
            { GLFW_KEY_PAGE_UP, Key.PageUp},
            { GLFW_KEY_PAGE_DOWN, Key.PageDown},
            { GLFW_KEY_HOME, Key.Home},
            { GLFW_KEY_END, Key.End},
            { GLFW_KEY_BACKSPACE, Key.Backspace},
            { GLFW_KEY_ENTER, Key.Return}
        };

        private Dictionary<int, Button> _buttonLookup = new Dictionary<int, Button>()
        {
            { GLFW_MOUSE_BUTTON_1, Button.Left },
            { GLFW_MOUSE_BUTTON_2, Button.Right },
            { GLFW_MOUSE_BUTTON_3, Button.Middle },
            { GLFW_MOUSE_BUTTON_4, Button.Thumb1 },
            { GLFW_MOUSE_BUTTON_5, Button.Thumb2 },
            { GLFW_MOUSE_BUTTON_6, Button.Extra1 },
            { GLFW_MOUSE_BUTTON_7, Button.Extra2 },
        };

        public Key GetKey(int glfwKey)
        {
            if (_keyLookup.ContainsKey(glfwKey))
                return _keyLookup[glfwKey];

            return Key.Unknown;
        }

        public int GetKey(Key key)
        {
            var result = _keyLookup.Where((x) => x.Value == key).Select(x => x.Key).ToArray();

            if (result.Length == 1)
                return result[0];

            return GLFW_KEY_UNKNOWN;
        }

        public Button GetButton(int glfwButton)
        {
            if (_buttonLookup.ContainsKey(glfwButton))
                return _buttonLookup[glfwButton];

            return Button.Unknown;
        }

        public int GetButton(Button button)
        {
            var result = _buttonLookup.Where((x) => x.Value == button).Select(x => x.Key).ToArray();

            if (result.Length == 1)
                return result[0];

            return GLFW_KEY_UNKNOWN;
        }
    }
}
