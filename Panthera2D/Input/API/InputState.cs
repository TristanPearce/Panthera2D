using Panthera2D.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Panthera2D.Input
{
    public abstract class InputState : IDisposable
    {
        public abstract Vector2 MousePosition { get; }


        #region "Virtual Extentions"

        public virtual bool IsKeyDown(Key key)
        {
            return GetKeysDown().Contains(key);
        }

        public virtual bool IsKeyJustDown(Key key)
        {
            return GetKeysJustDown().Contains(key);
        }
        public virtual bool IsKeyJustUp(Key key)
        {
            return GetKeysJustUp().Contains(key);
        }

        #endregion

        #region Abstract

        public abstract Button[] GetButtonsDown();

        public abstract Button[] GetButtonsJustDown();

        public abstract Button[] GetButtonsJustUp();

        /// <summary>
        /// Return all keys that are currently pressed
        /// </summary>
        /// <returns></returns>
        public abstract Key[] GetKeysDown();

        public abstract Key[] GetKeysJustDown();

        public abstract Key[] GetKeysJustUp();

        internal abstract void FrameBegin();

        internal abstract void FrameEnd();

        public abstract void Dispose();

        #endregion
    }
}
