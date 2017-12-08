using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_SortingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();

            PrintSortedArray(n, input);
        }

        private static void PrintSortedArray(int n, List<int> input)
        {
            input.Sort();
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
