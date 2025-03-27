using Panthera2D.Graphics.Drawbles;
using Panthera2D.Graphics.OpenGL;
using Panthera2D.Utility;

using System;
using System.Collections.Generic;
using System.Numerics;

using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics.Platform.OpenGL.Renderers;

public struct VertexPositionColor
{
    //position
    public float X;
    public float Y;

    //color
    public float R;
    public float G;
    public float B;
    public float A;

    public VertexPositionColor(float x, float y, float r, float g, float b, float a)
    {
        X = x;
        Y = y;

        R = r;
        G = g;
        B = b;
        A = a;
    }
}

internal sealed class OpenGLShapeRenderer : IDisposable
{
    private OpenGlVertexArrayObject _vao;
    private OpenGLVertexBufferLayout _layout;
    private OpenGLDeviceBuffer<VertexPositionColor> _vertexBuffer;
    private OpenGLDeviceBuffer<uint> _indexBuffer;
    private OpenGLShader _shader;

    private bool _disposed;

    private List<VertexPositionColor> _vertices;
    private List<uint> _indices;

    private Viewport viewport;

    public OpenGLShapeRenderer(Viewport viewport)
    {
        this.viewport = viewport;
        Initialize();
    }

    private void Initialize()
    {
        _vao = new OpenGlVertexArrayObject();
        _vao.Bind();
        _vertexBuffer = new OpenGLDeviceBuffer<VertexPositionColor>(DeviceBufferUsage.Vertex);
        _indexBuffer = new OpenGLDeviceBuffer<uint>(DeviceBufferUsage.Index);

        _layout = new OpenGLVertexBufferLayout();
        _layout.Push<float>(2); //Position
        _layout.Push<float>(4); //Color

        _vertices = new List<VertexPositionColor>();
        _indices = new List<uint>();

        var loader = new EmbeddedResourceLoader(typeof(Application).Assembly, "Panthera2D.res.");
        var vertex = loader.GetResourceString("shaders.Shape.vert");
        var fragment = loader.GetResourceString("shaders.Shape.frag");

        _shader = new OpenGLShader(vertex, fragment);
    }

    public void Render(Rectangle rectangle)
    {
        float r = rectangle.Color.R / 255f;
        float g = rectangle.Color.G / 255f;
        float b = rectangle.Color.B / 255f;
        float a = rectangle.Color.A / 255f;

        _vertices.AddRange(
        [
            new VertexPositionColor(rectangle.Left,     rectangle.Bottom,   r, g, b, a),
            new VertexPositionColor(rectangle.Left,     rectangle.Top,      r, g, b, a),
            new VertexPositionColor(rectangle.Right,    rectangle.Bottom,   r, g, b, a),
            new VertexPositionColor(rectangle.Right,    rectangle.Top,      r, g, b, a)
        ]);

        uint count = (uint)_vertices.Count;
        _indices.AddRange(
        [
            count - 4, // 0 
            count - 3, // 1
            count - 2, // 2

            count - 3, // 1
            count - 2, // 2
            count - 1, // 3
        ]);
    }

    public void Render(Line line)
    {
        float r = line.Color.R / 255f;
        float g = line.Color.G / 255f;
        float b = line.Color.B / 255f;
        float a = line.Color.A / 255f;

        var halfThickness = line.Thickness / 2;
        var dx = line.End.X - line.Start.X;
        var dy = line.End.Y - line.Start.Y;
        var length = MathF.Sqrt(dx * dx + dy * dy);
        var ux = dx / length;
        var uy = dy / length;

        var offsetX = -uy * halfThickness;
        var offsetY = ux * halfThickness;

        _vertices.AddRange([
            new() { A = a, B = b, G = g, R = r, X = line.Start.X + offsetX, Y = line.Start.Y + offsetY },
            new() { A = a, B = b, G = g, R = r, X = line.Start.X - offsetX, Y = line.Start.Y - offsetY },
            new() { A = a, B = b, G = g, R = r, X = line.End.X + offsetX, Y = line.End.Y + offsetY },
            new() { A = a, B = b, G = g, R = r, X = line.End.X - offsetX, Y = line.End.Y - offsetY },
        ]);

        uint count = (uint)_vertices.Count;
        _indices.AddRange(
        [
            count - 4, // 0 
            count - 3, // 1
            count - 2, // 2

            count - 3, // 1
            count - 2, // 2
            count - 1, // 3
        ]);
    }

    public void BeginFrame()
    {

    }

    public void EndFrame()
    {
        _vertexBuffer.Bind();
        _indexBuffer.Bind();

        _vertexBuffer.Update(_vertices.ToArray());
        _indexBuffer.Update(_indices.ToArray());

        _layout.Bind();
        _layout.Enable();

        _shader.Use();
        _shader.SetMat4("uProjectionMatrix", viewport.GetMatrix());

        glDrawElements(GL_TRIANGLES, _indices.Count, GL_UNSIGNED_INT, IntPtr.Zero);

        _vertices.Clear();
        _indices.Clear();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _vertexBuffer.Dispose();
                _indexBuffer.Dispose();
                _vao.Dispose();
                _shader.Dispose();
            }
            _disposed = true;
        }
    }

    ~OpenGLShapeRenderer()
    {
        Dispose(false);
    }
}

        