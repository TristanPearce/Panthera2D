using Panthera2D.Graphics;
using Panthera2D.Graphics.Drawbles;
using Panthera2D.Input;

using System;
using System.Numerics;

namespace Panthera2D.Samples;

public class PillowApplication() : Application()
{
    private float currentAngle = 0;

    private Line line = new Line()
    {
        Start = new Vector2(0, 0),
        End = new Vector2(0.5f, 0.5f),
        Color = Color.Black,
        Thickness = 0.003f
    };

    protected override void Initialize()
    {
        Renderer.Viewport.SetSize(new Vector2(2.2f, 2.2f));
        UpdatePoint();

        Input.KeyPressed += key => { if (key == Key.Space) Renderer.Clear(Color.Black); };
    }

    protected override void Render()
    {
        Renderer.Render(line);
    }

    protected override void Update()
    {
        currentAngle += MathF.PI * 2 * Framerate.ActualSecondsBetweenFrames;
        UpdatePoint();
    }

    private void UpdatePoint()
    {
        var cos = MathF.Cos(currentAngle);
        var sin = MathF.Sin(currentAngle);
        var tan = MathF.Tan(currentAngle);

        var x = MathF.Cos(currentAngle * 1f) + (MathF.Cos(currentAngle * 10f) / 50);
        var y = MathF.Sin(currentAngle * 50.2f) * MathF.Sin(currentAngle * 2.1f);
        var color = Color.FromHSL((currentAngle / 100) % (MathF.PI / 3f), 1f, 0.5f);

        line.Start = line.End;
        line.End = new Vector2(x, y);
        line.Color = color;
    }
}
