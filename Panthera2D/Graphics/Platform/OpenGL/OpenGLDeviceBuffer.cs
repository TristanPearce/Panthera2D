using System;

using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics.OpenGL
{
    public class OpenGLDeviceBuffer<T> : IDisposable, DeviceBuffer<T> where T : unmanaged
    {


        private uint _id;

        public DeviceBufferUsage Usage { get; protected set; }

        public uint Id => _id;

        public OpenGLDeviceBuffer(DeviceBufferUsage usage)
        {
            Usage = usage;

            glGenBuffers(1, ref _id);
            glBindBuffer((uint)Usage, _id);
        }

        public void Update(IntPtr dataPtr, int size)
        {
            glBufferData((uint)Usage, sizeof(byte) * size, dataPtr, GL_DYNAMIC_DRAW);
        }

        public void Update(byte[] data)
        {
            unsafe
            {
                fixed (void* ptr = data)
                {
                    glBufferData((uint)Usage, sizeof(byte) * data.Length, (IntPtr)ptr, GL_DYNAMIC_DRAW);
                }
            }
        }

        public void Update(T[] data)
        {
            unsafe
            {
                fixed (void* ptr = data)
                {
                    glBufferData((uint)Usage, sizeof(T) * data.Length, (IntPtr)ptr, GL_DYNAMIC_DRAW);
                }
            }
        }

        public void Bind()
        {
            glBindBuffer((uint)Usage, _id);
        }

        public void Dispose()
        {
            glDeleteBuffers(1, ref _id);
        }
    }
}
