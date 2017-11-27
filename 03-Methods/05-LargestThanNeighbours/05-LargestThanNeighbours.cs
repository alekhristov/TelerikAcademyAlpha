using System;
using System.Linq;

namespace _05_LargestThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            PrintNumberLargerThanNeighbours(n, input);
        }

        private static void PrintNumberLargerThanNeighbours(int n, int[] input)
        {
            var counter = 0;
          
            for (int i = 1; i < n - 1; i++)
            {
                var currentNum = input[i];
                if (currentNum >= input[i-1] && currentNum >= input[i+1])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
