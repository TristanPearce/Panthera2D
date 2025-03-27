using System;

namespace Panthera2D.Graphics.OpenGL
{
    public class OpenGLGraphicsDevice : IDisposable
    {

        private OpenGlVertexArrayObject _defaultVao;


        public OpenGLGraphicsDevice()
        {
            _defaultVao = new OpenGlVertexArrayObject();
            _defaultVao.Bind();
        }

        public GraphicsBackend Backend => GraphicsBackend.OpenGL;

        public void ClearBuffer()
        {
            Panthera2D.Native.OpenGL.glClearColor(0, 1, 1, 1);
            Panthera2D.Native.OpenGL.glClear(Panthera2D.Native.OpenGL.GL_COLOR_BUFFER_BIT);
        }

        public OpenGLDeviceBuffer<T> CreateDeviceBuffer<T>(DeviceBufferUsage usage) where T : unmanaged
        {
            return new OpenGLDeviceBuffer<T>(usage);
        }

        public Texture2D CreateTexture2D(int width, int height, Color[] pixels)
        {
            return new OpenGLTexture2D(width, height, pixels);
        }

        public void Dispose()
        {
            _defaultVao.Dispose();
        }
    }
}
