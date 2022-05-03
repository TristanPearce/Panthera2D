using System;
using System.Collections;
using System.Text;

namespace Panthera2D
{
    public static class IEnumerableExtentions
    {

        public static void WriteToConsole(this IEnumerable ienum)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (object o in ienum)
                sb.Append($"{o.ToString()}, ");

            if (sb.Length > 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }
                sb.Append("]");
            Console.WriteLine(sb.ToString());
        }

    }
}
