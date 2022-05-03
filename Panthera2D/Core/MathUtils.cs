using System;

namespace Panthera2D
{
    public static class MathUtils
    {
        public readonly static float DegToRad = (float)Math.PI / 180f;
        public readonly static float RadToDeg = 180f / (float)Math.PI;

        public static double Map(double value, double oldMin,
            double oldMax, double newMin, double newMax)
        {
            return newMin + (newMax - newMin) * ((value - oldMin) / (oldMax - oldMin));
        }
    }
}
