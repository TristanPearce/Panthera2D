using System;

using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics
{
    public class OpenGlVertexArrayObject : IDisposable
    {

        private uint _id;

        public OpenGlVertexArrayObject()
        {
            glCreateVertexArrays(1, ref _id);
        }

        public void Bind()
        {
            glBindVertexArray(_id);
        }

        public void Dispose()
        {
            glDeleteVertexArrays(1, ref _id);
        }
    }
}
