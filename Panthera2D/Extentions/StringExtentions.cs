using System.Text;

namespace Panthera2D
{
    public static class StringExtentions
    {

        public static byte[] GetBytes(this string str, Encoding encoding = null)
        {
            encoding = encoding ?? UTF8Encoding.UTF8;

            return encoding.GetBytes(str);
        }

    }
}
