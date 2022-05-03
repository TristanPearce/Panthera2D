using System;
using System.Collections.Generic;
using System.Text;

namespace Panthera2D.Graphics
{
    public interface IRenderer2D
    {
        void Rect(int x, int y, int width, int height, Color color);
        void Ellipse(int x, int y, int width, int height, Color color);
        void Texture(Texture2D tex, int x, int y, int width, int height, Color color);
        void Text(string text, int x, int y, Font font = null);
    }
}
