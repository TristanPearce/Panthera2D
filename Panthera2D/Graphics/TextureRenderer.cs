using Panthera2D.Utility;

using System;
using System.Collections.Generic;
using System.Numerics;

using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics
{
    public struct VertexPositionColorTexture
    {
        //position
        public float X;
        public float Y;
        public float Z;

        //color
        public float R;
        public float G;
        public float B;
        public float A;

        //texture
        public float U;
        public float V;

        public VertexPositionColorTexture(float x, float y, float z, float r, float g, float b, float a, float u, float v)
        {
            X = x;
            Y = y;
            Z = z;
            R = r;
            G = g;
            B = b;
            A = a;
            U = u;
            V = v;
        }
    }

    /// <summary>
    /// Renders Texture2D instances
    /// </summary>
    public class TextureRenderer : IDisposable
    {

        private EmbeddedResourceLoader _loader;

        private List<VertexPositionColorTexture> _vertices;
        private List<uint> _indices;

        private VertexBufferLayout _layout;

        private DeviceBuffer<VertexPositionColorTexture> _vertexBuffer;
        private DeviceBuffer<uint> _indexBuffer;
        private Shader _shader;

        private uint _currentTextureId;

        public TextureRenderer(GraphicsDevice device)
        {

            _loader = new EmbeddedResourceLoader(typeof(Game).Assembly, "Panthera2D.res.");

            _vertices = new List<VertexPositionColorTexture>();
            _indices = new List<uint>();

            _layout = new VertexBufferLayout();
            _layout.Push<float>(3); //Position
            _layout.Push<float>(4); //Color
            _layout.Push<float>(2); //UV

            _vertexBuffer = device.CreateDeviceBuffer<VertexPositionColorTexture>(DeviceBufferUsage.Vertex);
            _indexBuffer = device.CreateDeviceBuffer<uint>(DeviceBufferUsage.Index);


            //load shaders
            _shader = new Shader(
                _loader.GetResourceString("shaders.Basic.vert"),
                _loader.GetResourceString("shaders.Basic.frag"));
        }

        public void Begin()
        {
            _vertices.Clear();
            _indices.Clear();
        }

        public void Draw(Texture2D tex, float x, float y, float width, float height, float z = 0, float rotation = 0)
        {

            //this is to prevent swithing textures unless necessary
            if (_currentTextureId != tex.Id)
            {
                if (_vertices.Count != 0)
                {
                    Flush();

                    _vertices.Clear();
                    _indices.Clear();
                }

                //Console.WriteLine("Bound Texture: " + tex.Id);
                tex.Bind();
                _currentTextureId = tex.Id;
            }


            /*
            _vertices.AddRange(new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture((-0.5f * width) + x, (-0.5f * height) + y, 0f + z,   1f, 1f, 1f, 1f,     0f, 0f),
                new VertexPositionColorTexture(( 0.5f * width) + x, (-0.5f * height) + y, 0f + z,   1f, 1f, 1f, 1f,     1f, 0f),
                new VertexPositionColorTexture(( 0.5f * width) + x, ( 0.5f * height) + y, 0f + z,   1f, 1f, 1f, 1f,     1f, 1f),
                new VertexPositionColorTexture((-0.5f * width) + x, ( 0.5f * height) + y, 0f + z,   1f, 1f, 1f, 1f,     0f, 1f)
            });
            */

            //THIS IS WITH THE ORIGIN IN THE CENTRE OF THE IMAGE
            Vector2 bottomleft = new Vector2((-0.5f * width) + x, (-0.5f * height) + y).Rotate(rotation);
            Vector2 bottomright = new Vector2((0.5f * width) + x, (-0.5f * height) + y).Rotate(rotation);
            Vector2 topleft = new Vector2((-0.5f * width) + x, (0.5f * height) + y).Rotate(rotation);
            Vector2 topright = new Vector2((0.5f * width) + x, (0.5f * height) + y).Rotate(rotation);

            //THIS IS WHERE THE THE ORIGIN IS BOTTOM LEFT
            /*
            Vector2 bottomleft = new Vector2(x, y).Rotate(rotation);
            Vector2 bottomright = new Vector2(x + width, y).Rotate(rotation);
            Vector2 topleft = new Vector2(x, y + height).Rotate(rotation);
            Vector2 topright = new Vector2(x + width, y + height).Rotate(rotation);
            */

            _vertices.AddRange(new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(bottomleft.X,    bottomleft.Y,   z,      1f, 1f, 1f, 1f,     tex.Region.Left, tex.Region.Bottom),
                new VertexPositionColorTexture(bottomright.X,   bottomright.Y,   z,      1f, 1f, 1f, 1f,     tex.Region.Right, tex.Region.Bottom),
                new VertexPositionColorTexture(topright.X,   topright.Y,  z,      1f, 1f, 1f, 1f,     tex.Region.Right, tex.Region.Top),
                new VertexPositionColorTexture(topleft.X,    topleft.Y,  z,      1f, 1f, 1f, 1f,     tex.Region.Left, tex.Region.Top)
            });

            uint count = (uint)_vertices.Count;

            _indices.AddRange(new uint[]
            {
            count - 4, // 0 
            count - 3, // 1
            count - 2, // 2

            count - 4, // 0
            count - 2, // 2
            count - 1, // 3
            });
        }

        public void End()
        {
            Flush();
        }

        private void Flush()
        {
            _shader.Use();
            _shader.SetMat4("WP", Matrix4x4.Identity);

            _layout.Enable();
            _layout.Bind();

            //gets bound inside update
            _vertexBuffer.Update(_vertices.ToArray());
            //gets bound inside update
            _indexBuffer.Update(_indices.ToArray());

            glDrawElements(GL_TRIANGLES, _indices.Count, GL_UNSIGNED_INT, IntPtr.Zero);
            //glDrawArrays(GL_TRIANGLES, 0, 4);
        }

        public void Dispose()
        {
            _vertexBuffer.Dispose();
            _indexBuffer.Dispose();
            _shader.Dispose();
        }
    }
}
