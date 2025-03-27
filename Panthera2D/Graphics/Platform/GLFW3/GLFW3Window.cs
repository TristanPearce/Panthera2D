using System;

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
        private GLFWwindowclosefun _winCloseCallback;

        private IntPtr _handle;
        public IntPtr Handle => _handle;

        public bool Alive => glfwWindowShouldClose(Handle) == 0;

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

        public GLFW3Window(int width = 640, int height = 480, string title = "Panthera2D")
        {
            csglLoadGlfw();

            glfwInit();
            glfwWindowHint(GLFW_DOUBLEBUFFER, GL_FALSE);
            glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4); // Change this to your targeted major version
            glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 5); // Change this to your targeted minor version
            glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

            _handle = glfwCreateWindow(width, height, title, IntPtr.Zero, IntPtr.Zero);

            if (_handle == null)
                throw new Exception("Window could not be created!");

            size = new Vector2i(width, height);

            glfwMakeContextCurrent(_handle);

            //ENABLE OPEN GL FUNCTIONS
            //glEnable(GL_BLEND);
            //glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);


            _winCloseCallback = CloseCallback;

            glfwSetWindowCloseCallback(this._handle, _winCloseCallback);
        }

        private void CloseCallback(IntPtr window)
        {
            if (this.Handle != window) return;

            this.Dispose();
        }

        public void Render()
        {
            glfwSwapBuffers(_handle);
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
            glfwTerminate();
        }
    }
}
