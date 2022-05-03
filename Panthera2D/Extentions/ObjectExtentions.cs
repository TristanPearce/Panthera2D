using System;
using System.Collections.Generic;
using System.Text;

namespace Panthera2D
{
    public static class ObjectExtentions
    {

        public static void WriteToConsole(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }

    }
}
