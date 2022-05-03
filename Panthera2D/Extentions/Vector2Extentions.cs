using System;
using System.Numerics;

namespace Panthera2D
{
    public static class Vector2Extentions
    {

        public static Vector2 Rotate(this Vector2 vector, float radians)
        {
            float cos = MathF.Cos(radians);
            float sin = MathF.Sin(radians);

            float x = vector.X * cos + vector.Y * sin;
            float y = vector.Y * cos - vector.X * sin;

            return new Vector2(x, y);
        }

    }
}
