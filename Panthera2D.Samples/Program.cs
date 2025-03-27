using System;
using System.Threading;

using Panthera2D;
using Panthera2D.Samples.Drawables;

namespace Panthera2D.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new StartupInfo()
            {
                WindowHeight = 600,
                WindowWidth = 800,
                WindowTitle = "Panthera2D Samples"
            };
            //Application.RunOnNewThread<MyCanvas>(new StartupInfo());
            //Application.RunOnNewThread<MyCanvas>();
            //new MyCanvas().Run();
            new LineExample(info).Run();
        }
    }
}
