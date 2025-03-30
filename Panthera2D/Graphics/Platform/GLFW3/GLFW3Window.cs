using System;
using System.Threading;

using static Panthera2D.Native.Glfw3;
using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics.GLFW3
{
    /// <summary>
    /// A Graphical Window, currently implemented with GLFW should be abstracted and have
    /// platform specific implementations.
    /// </summary>
    public class GLFW3Window : IWindow
    {
        private GLFWwindowclosefun glfwCloseCallback;
        private GLFWwindowposfun glfwPositionCallback;
        private GLFWwindowsizefun glfwSizeCallback;
        private GLFWerrorfun glfwErrorCallback;

        private IntPtr handle;
        public IntPtr Handle => handle;

        public bool Alive { get; private set; }

        /// <summary>
        /// Width / Height
        /// </summary>
        public float AspectRatio => (float)Size.X/ (float)Size.Y;

        private Vector2i position;
        public Vector2i Position 
        {
            get => position;

            set
            {
                glfwSetWindowSize(Handle, value.X, value.Y);
                position = value;
            }
        }

        private Vector2i size;
        public Vector2i Size 
        {
            get
            {
                glfwGetWindowSize(Handle, ref size.X, ref size.Y);
                return size;
            }

            set
            {
                glfwSetWindowSize(Handle, value.X, value.Y);
                size = value;
            } 
        }

        private string title;
        public string Title 
        {
            get => title;
            set
            {
                glfwSetWindowTitle(Handle, value);
                title = value;
            }
        }

        private static object windowLock = new();
        private static int windowCount = 0;
        static GLFW3Window()
        {
            csglLoadGlfw();
        }

        public GLFW3Window(int width = 640, int height = 480, string title = "Panthera2D")
        {
            lock (windowLock)
            {
                if(windowCount == 0)
                    glfwInit();
                
                glfwWindowHint(GLFW_DOUBLEBUFFER, GL_FALSE);
                glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4); // Change this to your targeted major version
                glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 5); // Change this to your targeted minor version
                glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

                handle = glfwCreateWindow(width, height, title, IntPtr.Zero, IntPtr.Zero);

                if (handle == IntPtr.Zero)
                    throw new Exception("Window could not be created!");

                glfwPositionCallback = (window, x, y) =>
                {
                    position = new Vector2i(x, y);
                    Console.WriteLine($"Window moved to {x}, {y}");
                };

                glfwSizeCallback = (window, w, h) =>
                {
                    size = new Vector2i(w, h);
                    Console.WriteLine($"Window resized to {w}, {h}");
                };

                glfwErrorCallback = ((error, description) =>
                {
                    Console.WriteLine($"GLFW Error: {error} - {description}");
                });


                size = new Vector2i(width, height);
                glfwMakeContextCurrent(handle);

                //ENABLE OPEN GL FUNCTIONS
                //glEnable(GL_BLEND);
                //glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);


                glfwCloseCallback = CloseCallback;
                glfwSetWindowPosCallback(handle, glfwPositionCallback);
                glfwSetWindowSizeCallback(handle, glfwSizeCallback);
                glfwSetWindowCloseCallback(handle, glfwCloseCallback);
                glfwSetErrorCallback(glfwErrorCallback);

                Interlocked.Increment(ref windowCount);
                Alive = true;
            }
        }

        private void CloseCallback(IntPtr window)
        {
            if (this.Handle != window) return;

            this.Dispose();
        }

        public void Render()
        {
            glfwSwapBuffers(handle);
            //glFinish();
            //glFlush();
        }

        public void Update()
        {
            glfwPollEvents();
        }

        public void Dispose()
        {
            if (!Alive) return;

            glfwSetWindowShouldClose(Handle, 1);
            glfwDestroyWindow(Handle);

            Alive = false;

            Interlocked.Decrement(ref windowCount);

            if (windowCount == 0)
                glfwTerminate();
        }
    }
}
