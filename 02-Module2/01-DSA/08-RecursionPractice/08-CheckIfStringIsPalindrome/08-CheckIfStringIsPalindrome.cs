using System;

namespace _08_CheckIfStringIsPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckPalindrome("ceec"));
        }

        private static bool CheckPalindrome(string str)
        {
            if (str.Length < 2)
            {
                return true;
            }

            if (str[0] != str[str.Length - 1])
            {
                return false;
            }

            str = str.Substring(1, str.Length - 2);
            return CheckPalindrome(str);
        }
    }
}
