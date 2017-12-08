using System;

namespace _10_UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            foreach (var item in input)
            {
                Console.Write("\\u" + ((int)item).ToString("X4"));
            }
            Console.WriteLine();
        }
    }
}
