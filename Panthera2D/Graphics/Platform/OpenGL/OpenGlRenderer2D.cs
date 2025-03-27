using Panthera2D.Graphics.Drawbles;
using Panthera2D.Graphics.OpenGL;
using Panthera2D.Graphics.Platform.OpenGL.Renderers;

using System;

namespace Panthera2D.Graphics.Platform.OpenGL;

using static Panthera2D.Native.OpenGL;

public class OpenGlRenderer2D : IRenderer2D, IDisposable
{
    //private OpenGlTextureRenderer _textureRenderer;
    private OpenGLShapeRenderer shapeRenderer;

    public OpenGlRenderer2D()
    {
        shapeRenderer = new OpenGLShapeRenderer();
    }

    public void Render(Line line)
    {
        shapeRenderer.Render(line);
    }

    public void Render(Sprite sprite)
    {
        //_textureRenderer.Begin();
        //_textureRenderer.Draw(sprite.Texture, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
        //_textureRenderer.End();
    }

    public void Dispose()
    {
        //_textureRenderer.Dispose();
        shapeRenderer.Dispose();
    }

    public void BeginFrame()
    {
        glClearColor(0f, 0f, 0f, 1f);
        glClear(GL_COLOR_BUFFER_BIT);

        shapeRenderer.BeginFrame();
    }

    public void EndFrame()
    {
        shapeRenderer.EndFrame();
    }

    public void Render(Rectangle rectangle)
    {
        shapeRenderer.Render(rectangle);
    }

    private struct VertexPositionColor(float x, float y, float z, float r, float g, float b, float a)
    {
        //position
        public float X = x;
        public float Y = y;
        public float Z = z;

        //color
        public float R = r;
        public float G = g;
        public float B = b;
        public float A = a;
    }
}