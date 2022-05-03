using StbImageSharp;

using System.IO;
using System.Linq;

namespace Panthera2D.Graphics
{
    public static class GraphicsDeviceExtentions
    {

        public static Texture2D CreateTexture2D(this GraphicsDevice gd, Stream stream, bool disposeStream = true)
        {
            var image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

            if (disposeStream)
                stream.Dispose();

            byte[] bytes = image.Data;

            bytes = ReverseColorData(bytes);

            return gd.CreateTexture2D(image.Width, image.Height, FromBytesRGBA(ref bytes));
        }

        public static Texture2D CreateTexture2D(this GraphicsDevice gd, string path)
        {
            return gd.CreateTexture2D(new FileStream(path, FileMode.Open));
        }

        public static Texture2D CreateTexture2D(this GraphicsDevice gd, int width, int height)
        {
            return gd.CreateTexture2D(width, height, Enumerable.Repeat<Color>(Color.White, width * height).ToArray());
        }

        private static byte[] ReverseColorData(byte[] data)
        {

            //TODO: Implement a inplace sort, this uses to much memory
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
