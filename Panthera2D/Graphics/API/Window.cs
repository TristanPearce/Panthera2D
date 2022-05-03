using System;

namespace Panthera2D.Graphics
{
    /// <summary>
    /// A graphical window
    /// </summary>
    public abstract class Window : IDisposable
    {
        public abstract bool Alive { get; }
        public abstract IntPtr Handle { get; }
        public abstract int Height { get; }
        public abstract int Width { get; }

        public abstract void Dispose();

        /// <summary>
        /// Update the state of the window... Poll events
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Render available data to screen... Swap buffers
        /// </summary>
        public abstract void Render();
    }
}