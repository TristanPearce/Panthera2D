using Panthera2D.Core.Misc;

using System;

namespace Panthera2D.Graphics
{
    /// <summary>
    /// A graphical window
    /// </summary>
    public interface IWindow
    {

        bool Alive { get; }
        Vector2i Position{ get; set; }
        Vector2i Size { get; set; }

        string Title { get; set; }  

        /// <summary>
        /// Update the state of the window... Poll events
        /// </summary>
        void Update();

        /// <summary>
        /// Render available data to screen... Swap buffers
        /// </summary>
        void Render();
    }
}