using Panthera2D.Graphics;
using Panthera2D.Graphics.Drawbles;
using Panthera2D.Graphics.OpenGL;

using System;
using System.Numerics;

using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Samples.Drawables;

public class LineExample : Application
{

    Line one = new Line()
    {
        Start = new Vector2(-1f, -1f),
        End = new Vector2(1f, 1f),
        Color = Color.Red,
        Thickness = 0.01f
    };

    Line two = new Line()
    {
        Start = new Vector2(1f, -1f),
        End = new Vector2(-1f, 1f),
        Color = Color.Green,
        Thickness = 0.01f
    };

    Rectangle rectangle = new Rectangle()
    {
        X = 0,
        Y = 0,
        Width = 0.5f,
        Height = 0.5f,
        Color = Color.Blue
    };

    public LineExample(StartupInfo info) : base(info)
    {
        Input.KeyPressed += (key) => 
        {
            if (key == Panthera2D.Input.Key.Space)
            {
                rectangle.Color = new Color()
                {
                    R = (byte)Random.Shared.Next(0, 255),
                    G = (byte)Random.Shared.Next(0, 255),
                    B = (byte)Random.Shared.Next(0, 255),
                    A = 255
                };
            }
        };
    }

    private float angle = 0;

    protected override void Render()
    {
        Renderer.Render(rectangle);
        Renderer.Render(one);
        Renderer.Render(two);
    }

    protected override void Update()
    {
        angle += MathF.PI / 2f * (Framerate.ActualSecondsBetweenFrames);

        rectangle.X = MathF.Cos(angle) - rectangle.Width / 2f;
        rectangle.Y = MathF.Sin(angle) - rectangle.Height / 2f;
    }
}
