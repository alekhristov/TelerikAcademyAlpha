using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _12_IntegerCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();

            PrintIntegerCalculations(input);
        }

        private static void PrintIntegerCalculations(List<int> input)
        {
            Console.WriteLine(input.Min());
            Console.WriteLine(input.Max());
            Console.WriteLine("{0:f2}", input.Average());
            Console.WriteLine(input.Sum());

            BigInteger product = 1;
            for (int i = 0; i < input.Count; i++)
            {
                product *= input[i];
            }
            Console.WriteLine(product);
        }
    }
}
