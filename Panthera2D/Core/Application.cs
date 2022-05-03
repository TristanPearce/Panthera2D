using Panthera2D.Graphics;
using Panthera2D.Graphics.GLFW3;
using Panthera2D.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Panthera2D
{
    public abstract class Application : IDisposable
    {
        private Stopwatch _stopwatch;

        private StartupInfo _startupInfo;

        public Window Window { get; private set; }
        public GraphicsDevice GraphicsDevice { get; private set; }

        public InputState InputState { get; set; }

        public InputManager Input { get; private set; }

        /// <summary>
        /// In seconds
        /// </summary>
        public virtual float FrameTime { get; private set; }

        public float FramesPerSecond => 1f / FrameTime;

        public Application(StartupInfo info)
        {
            _stopwatch = new Stopwatch();

            _startupInfo = info;

            Create();
        }

        private void Create()
        {
            //if(OpenGL is supported)
            //for now, later on detect which platform to use
            Window = new Panthera2D.Graphics.GLFW3.GLFW3Window(_startupInfo.WindowWidth, _startupInfo.WindowHeight, _startupInfo.WindowTitle);
            GraphicsDevice = new Panthera2D.Graphics.OpenGL.OpenGLGraphicsDevice();
            InputState = new Input.GLFW3.GLFW3InputState(Window as GLFW3Window);

            Input = new InputManager(Window, InputState);
        }

        public void Run()
        {
            while (Window.Alive)
            {
                InputState.FrameBegin();
                if (ShouldRender())
                {
                    this.Render();
                    Window.Render();
                }
                InputState.FrameEnd();

                Window.Update();

                if (ShouldUpdate())
                    this.Update();

                Input.Update(FrameTime);

                FrameTime = (float)_stopwatch.Elapsed.TotalSeconds;
                _stopwatch.Restart();
            }
        }

        public void Run(uint frames)
        {
            while (Window.Alive && frames > 0)
            {
                InputState.FrameBegin();
                if (ShouldRender())
                {
                    Render();
                    Window.Render();
                }
                InputState.FrameEnd();
                Window.Update();

                if(ShouldUpdate())
                    Update();

                Input.Update(FrameTime);

                frames--;

                FrameTime = (float)_stopwatch.Elapsed.TotalSeconds;
                _stopwatch.Restart();
            }
        }

        protected abstract void Render();

        protected abstract void Update();

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
            Window.Dispose();
            GraphicsDevice.Dispose();
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
}
