using System;
using System.Threading;

using Panthera2D;

namespace Panthera2D.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Application.RunOnNewThread<MyCanvas>(new StartupInfo());
            //Application.RunOnNewThread<MyCanvas>();
            new MyCanvas().Run();
        }
    }
}
