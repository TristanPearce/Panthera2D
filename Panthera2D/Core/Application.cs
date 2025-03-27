using Panthera2D.Core.Misc;
using Panthera2D.Graphics;
using Panthera2D.Graphics.GLFW3;
using Panthera2D.Graphics.Platform.OpenGL;
using Panthera2D.Input;
using System;
using System.Diagnostics;
using System.Threading;

namespace Panthera2D;

public abstract class Application : IDisposable
{
    public required IWindow Window { get; init; }
    public required IRenderer2D Renderer { get; init; }
    public required InputState InputState { get; init; }

    public InputManager Input { get; private set; }

    protected Framerate Framerate { get; private set; }  = new Framerate();

    public Application()
    {
        Window = new GLFW3Window();
        InputState = new Input.GLFW3.GLFW3InputState(Window as GLFW3Window);
        Renderer = new OpenGlRenderer2D();
        Input = new InputManager(Window, InputState);

        Initialize();
    }

    protected virtual void Initialize() { }

    public void Run()
    {
        while (Window.Alive)
        {
            Tick();
        }
    }

    public void Run(uint frames)
    {
        while (Window.Alive && frames > 0)
        {
            Tick();
            frames--;
        }
    }

    private void Tick()
    {
        InputState.FrameBegin();
        if (ShouldRender() && Framerate.ShouldRender())
        {
            Framerate.Tick();
            Renderer.BeginFrame();
            Render();
            Renderer.EndFrame();
        }

        Window.Render();
        Window.Update();

        if (ShouldUpdate())
            Update();

        Input.Update(Framerate.Actual);

        InputState.FrameEnd();
    }

    protected virtual void Render() { }
    protected virtual void Update() { }

    /// <summary>
    /// Determines whether the application should currently be rendering
    /// </summary>
    /// <returns></returns>
    protected virtual bool ShouldRender()
    {
        return true;
    }

    /// <summary>
    /// Determines whether the application should currently be Updating
    /// </summary>
    /// <returns></returns>
    protected virtual bool ShouldUpdate()
    {
        return true;
    }

    public virtual void Dispose()
    {
        if (Window is IDisposable disposableWindow)
            disposableWindow.Dispose();

        InputState.Dispose();
    }

    /// Used to limit window creation to 1 window at a time.
    private static object _appCreationLock = new object();

    /// <summary>
    /// Runs the application on a new thread.
    /// </summary>
    /// <remarks>
    /// The calling thread is blocked until the application is created, 
    /// this is because of an issue with multiple OpenGL Contexts being created simultaneosly
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="info"></param>
    public static void RunOnNewThread<T>(params object[] args) where T : Application
    {
        lock (_appCreationLock)
        {
            // used to detect when application has been created.
            long status = 0;

            // New thread for applicaiton
            new Thread(() =>
            {
                Application app = (Application)Activator.CreateInstance(typeof(T), args);

                // Increment status to signal successful creation.
                Interlocked.Increment(ref status);

                app.Run();
                app.Dispose();
            }).Start();

            // While the window is being created, sleep.
            while (Interlocked.Read(ref status) == 0)
            {
                Thread.Sleep(5);
            }
        }
    }
}
