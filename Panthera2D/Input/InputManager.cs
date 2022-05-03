using Panthera2D.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Panthera2D.Input
{
    public sealed class InputManager
    {

        private InputState _state;
        private Window _window;

        private IDictionary<Key, float> _keysHeld;

        public event Action<Key> KeyPressed;
        public event Action<Key> KeyReleased;

        public event Action<Button> MousePressed;
        public event Action<Button> MouseReleased;

        private Vector2 _normMousePos;
        public Vector2 NormalisedMousePosition
        {
            get
            {
                _normMousePos.X = _state.MousePosition.X / _window.Width;
                _normMousePos.Y = _state.MousePosition.Y / _window.Height;

                return _normMousePos;
            }
        }

        public InputManager(Window window, InputState state)
        {
            this._window = window;
            this._state = state;

            _normMousePos = new Vector2();

            _keysHeld = new Dictionary<Key, float>();
        }

        internal void Update(float deltaTime)
        {
            //Invoke key pressed/released events
            {
                Key[] keys;

                keys = _state.GetKeysJustDown();
                foreach (Key key in keys)
                {
                    KeyPressed?.Invoke(key);

                    _keysHeld.Add(key, 0);
                }

                keys = _state.GetKeysJustUp();
                foreach (Key key in keys)
                {
                    KeyReleased?.Invoke(key);

                    _keysHeld.Remove(key);
                }
            }

            //Update keys held timer
            {
                var keys = _keysHeld.Keys.ToArray();
                foreach (Key key in keys)
                {
                    _keysHeld[key] += deltaTime;
                }
            }

            //Invoke key pressed/released events
            {
                Button[] buttons;

                buttons = _state.GetButtonsJustDown();
                foreach (Button button in buttons)
                {
                    MousePressed?.Invoke(button);
                }

                buttons = _state.GetButtonsJustUp();
                foreach (Button button in buttons)
                {
                    MouseReleased?.Invoke(button);
                }
            }
        }

        public float GetKeyHeldTime(Key key)
        {
            if (_keysHeld.ContainsKey(key))
                return _keysHeld[key];
            else
                return 0f;
        }

        public IReadOnlyDictionary<Key, float> GetHeldKeys()
        {
            return new ReadOnlyDictionary<Key, float>(_keysHeld);
        }
    }
}
