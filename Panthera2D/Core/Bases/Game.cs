using Panthera2D.Graphics;

using static Panthera2D.Native.Glfw3;
using static Panthera2D.Native.OpenGL;

namespace Panthera2D
{
    public abstract class Game : Application
    {
        public float DeltaTime { get; private set; }

        public Camera Camera { get; protected set; }

        public float TargetFrameTime { get; set; } = 0;

        public float TargetFPS
        {
            get => 1 / TargetFrameTime;
            set => TargetFrameTime = 1 / value;
        }

        public Game(StartupInfo info) : base(info)
        {
            Camera = new Camera();
        }

        public new void Run()
        {

            float previousFrameEnd = 0;

            float tempTime = 0;

            Init();
            while (Window.Alive)
            {
                tempTime = (float)glfwGetTime();
                if (glfwGetTime() - previousFrameEnd >= TargetFrameTime)
                {
                    glClearColor(0, 0, 0, 1);
                    glClear(GL_COLOR_BUFFER_BIT);

                    Render();

                    Window.Render();



                    DeltaTime = tempTime - previousFrameEnd;
                    previousFrameEnd = tempTime;
                }
                Window.Update();
            }
        }

        protected abstract void Init();

        public virtual new void Dispose()
        {
            Window.Dispose();
        }
    }
}
