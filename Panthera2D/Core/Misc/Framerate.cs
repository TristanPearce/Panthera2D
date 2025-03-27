using System.Diagnostics;

namespace Panthera2D.Core.Misc;

public sealed class Framerate
{
    private double targetSecondsBetweenFrames = 0;
    private double actualSecondsBetweenFrames = 0;

    public float TargetSecondsBetweenFrames 
    { 
        get => (float) targetSecondsBetweenFrames; 
        set => targetSecondsBetweenFrames = value; 
    }

    public float ActualSecondsBetweenFrames => (float) actualSecondsBetweenFrames;

    public float Target
    {
        get => (float)(1.0 / targetSecondsBetweenFrames);
        set => targetSecondsBetweenFrames = 1.0 / value;
    }

    public float Actual 
    { 
        get => (float)(1 / actualSecondsBetweenFrames);
    }

    private Stopwatch stopwatch;

    public Framerate()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    public void Tick()
    {
        stopwatch.Stop();
        actualSecondsBetweenFrames = stopwatch.Elapsed.TotalSeconds;
        stopwatch.Restart();
    }

    public bool ShouldRender()
    {
        return stopwatch.Elapsed.TotalSeconds >= targetSecondsBetweenFrames;
    }
}
