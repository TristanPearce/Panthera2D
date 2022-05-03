using Panthera2D.Graphics;
using Panthera2D.Input;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panthera2D.Samples
{
    public class MyCanvas : Canvas
    {

        private ConcurrentQueue<Color> _queue;

        public Color color = Color.White;

        public MyCanvas()
            : base(480, 480, "My Canvas")
        {

            _queue = new ConcurrentQueue<Color>();

            SetResolution(10, 10);

            Pixel(5, 5, Color.Red);

            Input.KeyPressed += (k) =>
            {
                switch (k)
                {
                    case Key.Up:
                        SetResolution(Resolution.X + 10, Resolution.Y + 10);
                        break;
                    case Key.Down:
                        SetResolution(Resolution.X - 10, Resolution.Y - 10);
                        break;
                    case Key.N1:
                        //Application.RunOnNewThread<MyColorPicker>(_queue);
                        break;
                }

            };

            Input.KeyPressed += (key) =>
            {
                switch (key)
                {
                    case Key.W:
                        color = Color.Red;
                        break;
                    case Key.Q:
                        color = Color.White;
                        break;
                    case Key.E:
                        color = Color.Green;
                        break;
                }
            };

            Input.MousePressed += (button) =>
            {
                switch (button)
                {
                    case Button.Left:
                        Paint(color);
                        break;
                    case Button.Right:
                        Paint(Color.White);
                        break;
                }
            };
        }

        private void Paint(Color c)
        {
            int x = (int)MathUtils.Map(Input.NormalisedMousePosition.X, 0, 1, 0, Resolution.X);
            int y = (int)MathUtils.Map(Input.NormalisedMousePosition.Y, 0, 1, Resolution.Y, 0);

            Pixel(x, y, c);
        }

        protected override void Update()
        {
            if (_queue.TryDequeue(out Color outColor))
            {
                color = outColor;
                Console.WriteLine("Color changed: " + color.ToString());
            }
        }
    }
}
