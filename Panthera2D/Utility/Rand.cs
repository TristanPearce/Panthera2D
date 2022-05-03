using Panthera2D.Graphics;

namespace Panthera2D
{
    /// <summary>
    /// Not threadsafe
    /// </summary>
    public static class Rand
    {
        private static System.Random _rand = new System.Random();

        public static int Int(int max)
        {
            return _rand.Next(max);
        }

        public static int Int(int min = 0, int max = int.MaxValue)
        {
            return _rand.Next(min, max);
        }

        public static float Float(float max)
        {
            return Float(0, max);
        }

        public static float Float(float min = 0, float max = 1)
        {
            return (float)MathUtils.Map(_rand.NextDouble(), 0, 1, min, max);
        }

        public static double Double(double max)
        {
            return Double(0, max);
        }

        public static double Double(double min = 0, double max = 1)
        {
            return MathUtils.Map(_rand.NextDouble(), 0, 1, min, max);
        }

        public static Color Color(float alpha = 1f)
        {
            return new Color(
                (float)_rand.NextDouble(),
                (float)_rand.NextDouble(),
                (float)_rand.NextDouble(),
                alpha);
        }

        public static Color[] Colors(int count)
        {
            Color[] array = new Color[count];

            for (int i = 0; i < count; i++)
            {
                array[i] = Rand.Color();
            }

            return array;
        }

    }
}
