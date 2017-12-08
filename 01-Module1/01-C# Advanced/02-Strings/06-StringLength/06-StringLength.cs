using System;

namespace _06_StringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stars = string.Empty;

            if (input.Length < 20)
            {
                for (int i = 0; i < 20 - input.Length; i++)
                {
                    stars += '*';
                }
            }
            Console.WriteLine(input + stars);
        }
    }
}
