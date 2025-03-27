using System;

namespace Panthera2D.Graphics.Drawbles
{
    [Serializable]
    public struct Rectangle
    {
        public Color Color;

        public float X;
        public float Y;
        public float Width;
        public float Height;

        public float Left => X;
        public float Right => X + Width;

        public float Bottom => Y;
        public float Top => Y + Height;

        public Rectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Overlaps(Rectangle target) 
        {
            if (this.Bottom < target.Top)
                if (this.Top > target.Bottom)
                    if (this.Left < target.Right)
                        if (target.Right > target.Left)
                            return true;
            return false;
        }
    }
}
