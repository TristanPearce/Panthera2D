using System.Runtime.InteropServices;

namespace Panthera2D
{
    [StructLayout(LayoutKind.Sequential)]
    public class StartupInfo
    {
        public int WindowWidth = 400;
        public int WindowHeight = 400;
        public string WindowTitle = "My Application";
    }
}
