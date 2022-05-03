using System;

namespace Panthera2D.Graphics
{
    /// <summary>
    /// A two dimentional texture
    /// </summary>
    public abstract class Texture2D : IDisposable
    {

        public virtual Color this[int x, int y]
        {
            get
            {
                return GetPixel(x, y);
            }

            set
            {
                SetPixel(x, y, value);
            }
        }

        public virtual Color[] GetPixels()
        {
            return this.GetPixels(0, 0, this.Width, this.Height);
        }

        public virtual Color GetPixel(int x, int y)
        {
            Bind();

            var colors = this.GetPixels(x, y, 1, 1);

            if (colors.Length == 1)
                return colors[0];
            else
                return Color.Red;
        }

        public virtual void SetPixels(Color[] pixels)
        {
            this.SetPixels(0, 0, this.Width, this.Height, pixels);
        }

        public virtual void SetPixel(int x, int y, Color color)
        {
            this.SetPixels(x, y, 1, 1, new Color[] { color });
        }

        #region abstract

        public abstract uint Id { get; }

        public abstract int Height { get; }
        public abstract int Width { get; }

        public abstract Rectangle Region { get; }

        public abstract void Bind();

        public abstract void Dispose();

        public abstract Color[] GetPixels(int xOffset, int yOffset, int width, int height);

        public abstract void SetPixels(int xOffset, int yOffset, int width, int height, Color[] pixels);

        #endregion
    }
}