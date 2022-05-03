using Panthera2D.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panthera2D
{
    public abstract class Canvas : Application
    {

        private TextureRenderer _renderer;

        private Texture2D _fullscreenTexture;

        //too much object creation, cache instead
        public Vector2i Resolution => new Vector2i() { X = _fullscreenTexture.Width, Y = _fullscreenTexture.Height }; 

        public Canvas(int width, int height, string title)
            : this(new StartupInfo() { WindowWidth = width, WindowHeight = height, WindowTitle = title })
        { }

        public Canvas(StartupInfo info) 
            : base(info)
        {
            _renderer = new TextureRenderer(GraphicsDevice);

            _fullscreenTexture = GraphicsDevice.CreateTexture2D(info.WindowWidth, info.WindowHeight);
        }

        public void SetResolution(int width, int height)
        {
            Texture2D newTex = _fullscreenTexture.Resize(width, height);
            _fullscreenTexture.Dispose();

            //maybe implement some sort of texture resizing function

            _fullscreenTexture = newTex;
        }

        public void Pixel(int x, int y, Color color)
        {
            _fullscreenTexture.SetPixel(x, y, color);
        }

        public void SetPixels(Color[] pixels)
        {
            _fullscreenTexture.SetPixels(pixels);
        }

        public Color GetPixel(int x, int y)
        {
            return _fullscreenTexture.GetPixel(x, y);
        }

        public Color[] GetPixels()
        {
            return _fullscreenTexture.GetPixels();
        }

        protected override void Render()
        {
            _renderer.Begin();

            _renderer.Draw(_fullscreenTexture, 0, 0, 2, 2);

            _renderer.End();
        }

        protected abstract override void Update();

        public override void Dispose()
        {
            base.Dispose();

            _renderer.Dispose();

            _fullscreenTexture.Dispose();
        }
    }
}
