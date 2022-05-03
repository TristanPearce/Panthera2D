using System;

namespace Panthera2D.Graphics
{
    /// <summary>
    /// Represents a graphics device
    /// </summary>
    public abstract class GraphicsDevice : IDisposable
    {
        /// <summary>
        /// which graphics backend is used
        /// </summary>
        public abstract GraphicsBackend Backend { get; }

        public abstract void ClearBuffer();

        public abstract Texture2D CreateTexture2D(int width, int height, Color[] pixels);

        public abstract DeviceBuffer<T> CreateDeviceBuffer<T>(DeviceBufferUsage usage) where T : unmanaged;

        public abstract void Dispose();
    }
}
