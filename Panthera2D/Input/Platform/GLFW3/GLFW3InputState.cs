using Panthera2D.Graphics;
using Panthera2D.Graphics.GLFW3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using static Panthera2D.Native.Glfw3;

namespace Panthera2D.Input.GLFW3
{
    public class GLFW3InputState : InputState
    {

        private HashSet<Key> _downKeys;
        private HashSet<Key> _justDownKeys;
        private HashSet<Key> _justUpKeys;

        private HashSet<Button> _downButtons;
        private HashSet<Button> _justDownButtons;
        private HashSet<Button> _justUpButtons;

        private GLFW3InputConverter _inputConverter;

        private readonly GLFWkeyfun _keyCallback;
        private readonly GLFWmousebuttonfun _buttonCallback;
        private readonly GLFWcursorposfun _cursorPosCallback;

        private IntPtr _window;

        private Vector2 _mousePos;

        public override Vector2 MousePosition => _mousePos;

        public GLFW3InputState(GLFW3Window window)
        {

            _window = window.Handle;

            _mousePos = new Vector2();

            _inputConverter = new GLFW3InputConverter();

            _downKeys = new HashSet<Key>(256);
            _justDownKeys = new HashSet<Key>(256);
            _justUpKeys = new HashSet<Key>(256);

            _downButtons = new HashSet<Button>(256);
            _justDownButtons = new HashSet<Button>(256);
            _justUpButtons = new HashSet<Button>(256);


            //assign callbacks to delegates so they dont get garbage collected
            _keyCallback = KeyCallback;
            _buttonCallback = ButtonCallback;
            _cursorPosCallback = CursorPositionCallback;

            //GLFW set callbacks
            glfwSetKeyCallback(_window, _keyCallback);
            glfwSetMouseButtonCallback(_window, _buttonCallback);
            glfwSetCursorPosCallback(_window, _cursorPosCallback);
        }

        #region Callbacks
        private void KeyCallback(IntPtr window, int glfwKey, int scancode, int action, int mods)
        {
            if (window != _window) return; //if the callback isnt for the window backing this input manager

            Key key = _inputConverter.GetKey(glfwKey);

            if (action == GLFW_PRESS)
            {
                if (!_downKeys.Contains(key))
                {
                    _justDownKeys.Add(key);

                    _downKeys.Add(key);
                }
            }
            else if (action == GLFW_RELEASE)
            {
                _downKeys.Remove(key);

                _justUpKeys.Add(key);
            }
        }

        private void ButtonCallback(IntPtr window, int glfwButton, int action, int mods)
        {
            if (window != _window) return; //if the call back isnt for the window backing this input manager

            Button button = _inputConverter.GetButton(glfwButton);

            if (action == GLFW_PRESS)
            {
                if (!_downButtons.Contains(button))
                {
                    _justDownButtons.Add(button);
                    _downButtons.Add(button);
                }
            }
            else if (action == GLFW_RELEASE)
            {
                _downButtons.Remove(button);
                _justUpButtons.Add(button);
            }
        }

        private void CursorPositionCallback(IntPtr window, double xpos, double ypos)
        {
            if (window != _window) return; //if the call back isnt for the window backing this input manager

            _mousePos.X = (float)xpos;
            _mousePos.Y = (float)ypos;
        }

        #endregion

        public override Key[] GetKeysDown()
        {
            return _downKeys.ToArray();
        }

        public override void Dispose()
        {
            _downKeys = null;
            _justUpKeys = null;
            _justDownKeys = null;

            _downButtons = null;
            _justDownButtons = null;
            _justUpButtons = null;
        }

        public override Key[] GetKeysJustDown()
        {
            return _justDownKeys.ToArray();
        }

        public override Key[] GetKeysJustUp()
        {
            return _justUpKeys.ToArray();
        }

        public override Button[] GetButtonsDown()
        {
            return _downButtons.ToArray();
        }

        public override Button[] GetButtonsJustDown()
        {
            return _justDownButtons.ToArray();
        }

        public override Button[] GetButtonsJustUp()
        {
            return _justUpButtons.ToArray();
        }

        internal override void FrameBegin()
        {
            
        }

        internal override void FrameEnd()
        {
            _justDownKeys.Clear();
            _justUpKeys.Clear();

            _justDownButtons.Clear();
            _justUpButtons.Clear();
        }
    }
}
