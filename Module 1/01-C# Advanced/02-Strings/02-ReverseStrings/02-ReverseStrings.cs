using System;

namespace _02_ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            Array.Reverse(cArray);
            text = new string(cArray);

            Console.WriteLine(text);

            //for (int i = cArray.Length - 1; i >= 0; i--)
            //{
            //    reverse += cArray[i];
            //}
            //Console.WriteLine(reverse);

        }
    }
}
