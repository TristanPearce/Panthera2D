using StbImageSharp;

using System;
using System.IO;
using System.Linq;

using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics
{
    public class OpenGLTexture2D : Texture2D
    {
        private uint _id = 0;

        private int _width;
        private int _height;

        public override int Width => _width;
        public override int Height => _height;

        public override uint Id => _id;

        private Rectangle _region = new Rectangle(0, 0, 1, 1);
        public override Rectangle Region => _region;

        public OpenGLTexture2D(int width, int height) :
            this(width, height, Enumerable.Repeat(Color.White, width * height).ToArray())
        {
        }

        public OpenGLTexture2D(int width, int height, Color[] data)
        {
            //make sure that data.length == width * height

            if (data.Length != width * height)
                throw new ArgumentException("Not enough pixels passed to fill the texture (data.Length != width * height)");

            this._width = width;
            this._height = height;

            CreateOpenGlTexture(ref data);
        }

        public OpenGLTexture2D(int width, int height, IntPtr data)
        {
            //make sure that data.length == width * height

            this._width = width;
            this._height = height;

            Color[] pixels = new Color[width * height];

            unsafe
            {
                Color* b = (Color*)data;

                for (int i = 0; i < width * height; i += 4)
                {
                    pixels[i] = b[i];
                }
            }

            CreateOpenGlTexture(ref pixels);
        }

        public OpenGLTexture2D(string path)
            : this(new FileStream(path, FileMode.Open), true)
        {
        }

        public OpenGLTexture2D(Stream stream, bool disposeSteam = true)
        {
            var image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

            if (disposeSteam)
                stream.Dispose();

            byte[] bytes = image.Data;

            //bytes = ReverseColorData(bytes);

            _width = image.Width;
            _height = image.Height;

            Color[] data = FromBytesRGBA(ref bytes);

            CreateOpenGlTexture(ref data);
        }



        private void CreateOpenGlTexture(ref Color[] data)
        {
            Dispose();

            glCreateTextures(GL_TEXTURE_2D, 1, ref _id);
            glBindTexture(GL_TEXTURE_2D, _id);

            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, (int)GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, (int)GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, (int)GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, (int)GL_NEAREST);

            unsafe
            {
                fixed (void* ptr = data)
                {
                    glTexImage2D(GL_TEXTURE_2D,
                        0,
                        (int)GL_RGBA,
                        Width,
                        Height,
                        0,
                        GL_RGBA,
                        GL_UNSIGNED_BYTE,
                        (IntPtr)ptr);
                }
            }
            //glGenerateMipmap(GL_TEXTURE_2D);
        }

        public override void Bind()
        {
            glBindTexture(GL_TEXTURE_2D, _id);
        }

        public override Color[] GetPixels(int xOffset, int yOffset, int width, int height)
        {
            this.Bind();

            Color[] data = new Color[(width * height)];

            unsafe
            {
                fixed (Color* ptr = data)
                {
                    glGetTextureSubImage(_id, 0, xOffset, yOffset, 0, width, height, 1, GL_RGBA, GL_UNSIGNED_BYTE, sizeof(Color) * data.Length, (IntPtr)ptr);
                    //glGetTextureImage(_id, 0, GL_RGBA, GL_UNSIGNED_BYTE, sizeof(Color) * data.Length,(IntPtr)ptr);
                    //glGetTexImage(GL_TEXTURE_2D, 0, GL_RGBA, GL_UNSIGNED_BYTE, (IntPtr)ptr);
                }
            }

            return data;
        }

        public override void SetPixels(int xOffset, int yOffset, int width, int height, Color[] pixels)
        {
            if (pixels.Length != width * height)
                throw new ArgumentException("Incorrect number of pixels passed to fill the region (pixels.Length != width * height)");

            this.Bind();

            unsafe
            {
                fixed (void* ptr = pixels)
                {
                    glTexSubImage2D(
                        GL_TEXTURE_2D,
                        0,
                        xOffset,
                        yOffset,
                        width,
                        height,
                        GL_RGBA,
                        GL_UNSIGNED_BYTE,
                        (IntPtr)ptr
                        );
                }
            }
        }

        public override void Dispose()
        {
            glDeleteTextures(1, new uint[] { _id });
        }

        private static byte[] ReverseColorData(byte[] data)
        {

            //TODO: Implement a inplace sort, this uses too much memory
            byte[] result = new byte[data.Length];

            int l = data.Length;

            // Convert rgba to bgra
            for (int i = 0; i < l / 4; i++)
            {
                byte r = data[i * 4];
                byte g = data[i * 4 + 1];
                byte b = data[i * 4 + 2];
                byte a = data[i * 4 + 3];


                result[l - i * 4 - 4] = r;
                result[l - i * 4 - 3] = g;
                result[l - i * 4 - 2] = b;
                result[l - i * 4 - 1] = a;
            }

            return result;
        }

        private static Color[] FromBytesRGBA(ref byte[] bytes)
        {
            int length = bytes.Length / 4;
            Color[] colors = new Color[length];

            for (int i = 0; i < length; i++)
            {
                Color c = new Color()
                {
                    R = bytes[i * 4 + 0],
                    G = bytes[i * 4 + 1],
                    B = bytes[i * 4 + 2],
                    A = bytes[i * 4 + 3]
                };

                colors[i] = c;
            }

            return colors;
        }


    }
}
