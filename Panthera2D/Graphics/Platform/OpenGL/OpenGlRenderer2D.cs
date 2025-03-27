using Panthera2D.Graphics.Drawbles;
using Panthera2D.Graphics.OpenGL;
using Panthera2D.Graphics.Platform.OpenGL.Renderers;

using System;

namespace Panthera2D.Graphics.Platform.OpenGL;

using static Panthera2D.Native.OpenGL;

public sealed class OpenGlRenderer2D : IRenderer2D, IDisposable
{
    private OpenGLShapeRenderer shapeRenderer;

    public Viewport Viewport { get; private set; }

    public OpenGlRenderer2D()
    {
        Viewport = new Viewport();
        shapeRenderer = new OpenGLShapeRenderer(Viewport);
    }

    public void Render(Line line)
    {
        shapeRenderer.Render(line);
    }

    public void Render(Rectangle rectangle)
    {
        shapeRenderer.Render(rectangle);
    }

    public void Render(Sprite sprite)
    {

    }

    public void Dispose()
    {
        shapeRenderer.Dispose();
    }

    public void BeginFrame()
    {
        shapeRenderer.BeginFrame();
    }

    public void EndFrame()
    {
        shapeRenderer.EndFrame();
    }

    public void Clear(Color color)
    {
        glClearColor(color.R, color.G, color.B, color.A);
        glClear(GL_COLOR_BUFFER_BIT);
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