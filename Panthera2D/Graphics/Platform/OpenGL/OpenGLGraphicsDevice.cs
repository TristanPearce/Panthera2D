namespace Panthera2D.Graphics.OpenGL
{
    public class OpenGLGraphicsDevice : GraphicsDevice
    {

        private VertexArrayObject _defaultVao;


        public OpenGLGraphicsDevice()
        {
            _defaultVao = new VertexArrayObject();
            _defaultVao.Bind();
        }

        public override GraphicsBackend Backend => GraphicsBackend.OpenGL;

        public override void ClearBuffer()
        {
            Panthera2D.Native.OpenGL.glClearColor(0, 1, 1, 1);
            Panthera2D.Native.OpenGL.glClear(Panthera2D.Native.OpenGL.GL_COLOR_BUFFER_BIT);
        }

        public override DeviceBuffer<T> CreateDeviceBuffer<T>(DeviceBufferUsage usage)
        {
            return new OpenGLDeviceBuffer<T>(usage);
        }

        public override Texture2D CreateTexture2D(int width, int height, Color[] pixels)
        {
            return new OpenGLTexture2D(width, height, pixels);
        }

        public override void Dispose()
        {
            _defaultVao.Dispose();
        }
    }
}
