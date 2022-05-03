namespace Panthera2D.Graphics
{
    public enum DeviceBufferUsage : uint
    {
        Undefined = 0,
        Vertex = Panthera2D.Native.OpenGL.GL_ARRAY_BUFFER,
        Index = Panthera2D.Native.OpenGL.GL_ELEMENT_ARRAY_BUFFER,
        Color,
        Depth
    }
}
