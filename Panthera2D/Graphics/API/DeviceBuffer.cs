using System;

namespace Panthera2D.Graphics
{
    /// <summary>
    /// Represents a graphics hardware buffer, can be used to store abitrary data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface DeviceBuffer<T> : IDisposable where T : unmanaged
    {
        uint Id { get; }
        DeviceBufferUsage Usage { get; }

        void Bind();
        void Update(T[] data);
    }
}