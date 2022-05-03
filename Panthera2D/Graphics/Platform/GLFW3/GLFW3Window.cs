using System;

using static Panthera2D.Native.Glfw3;
using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics.GLFW3
{
    /// <summary>
    /// A Graphical Window, currently implemented with GLFW should be abstracted and have
    /// platform specific implementations.
    /// </summary>
    public class GLFW3Window : Window
    {

        private GLFWwindowclosefun _winCloseCallback;

        private IntPtr _handle;
        public override IntPtr Handle => _handle;

        public override bool Alive => glfwWindowShouldClose(Handle) == 0;

        private int _width;
        private int _height;

        public override int Width => _width;
        public override int Height => _height;

        /// <summary>
        /// Width / Height
        /// </summary>
        public float AspectRatio => (float)Width / (float)Height;

        public GLFW3Window(int width = 640, int height = 480, string title = "Panthera2D")
        {
            csglLoadGlfw();

            glfwInit();
            glfwWindowHint(GLFW_DOUBLEBUFFER, GL_FALSE);
            glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4); // Change this to your targeted major version
            glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 5); // Change this to your targeted minor version
            glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

            _handle = glfwCreateWindow(width, height, title, IntPtr.Zero, IntPtr.Zero);

            if (Handle == null)
                throw new Exception("Window could not be created!");

            _width = width;
            _height = height;

            glfwMakeContextCurrent(Handle);

            //ENABLE OPEN GL FUNCTIONS
            glEnable(GL_BLEND);
            glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);


            _winCloseCallback = CloseCallback;

            glfwSetWindowCloseCallback(this.Handle, _winCloseCallback);
        }

        private void CloseCallback(IntPtr window)
        {
            if (this.Handle != window) return;

            this.Dispose();
        }

        public override void Render()
        {
            //glfwSwapBuffers(Handle);
            glFinish();
            glFlush();
        }

        public override void Update()
        {
            glfwPollEvents();
        }

        public override void Dispose()
        {
            if (!Alive) return;

            glfwSetWindowShouldClose(Handle, 1);

            glfwDestroyWindow(Handle);
            glfwTerminate();
        }
    }
}
