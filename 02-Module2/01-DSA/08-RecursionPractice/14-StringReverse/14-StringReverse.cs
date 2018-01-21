using System;

namespace _14_StringReverse
{
    class StringReverse
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseString("12345"));
        }

        private static string ReverseString(string str)
        {
            if (str.Length == 0)
            {
                return str;
            }

            var newStr = str.Substring(0, str.Length - 1);
            var result = str[str.Length - 1] + ReverseString(newStr);
            return result;
        }
    }
}
