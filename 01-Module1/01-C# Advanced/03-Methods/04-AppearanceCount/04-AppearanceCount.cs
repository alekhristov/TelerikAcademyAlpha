using System;
using System.Linq;

namespace _04_AppearanceCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var number = int.Parse(Console.ReadLine());

            NumberAppereanceCount(n, input, number);
        }

        private static void NumberAppereanceCount(int n, int[] input, int number)
        {
            var counter = 0;
            for (int i = 0; i < n; i++)
            {
                if (input[i] == number)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
