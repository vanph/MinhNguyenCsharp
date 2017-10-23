using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public static class TestExtenstion
    {
        public static int CoundWord(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Hello(this string str)
        {
            return $"Hello {str}";
        }

        public static int MultiplyBy(this int number, int factor)
        {
            return number * factor;
        }
    }
}
