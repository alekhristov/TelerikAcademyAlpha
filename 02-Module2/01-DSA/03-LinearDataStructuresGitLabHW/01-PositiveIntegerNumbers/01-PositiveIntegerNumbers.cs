using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_PositiveIntegerNumbers
{
    class PositiveIntegerNumbers
    {
        static void Main(string[] args)
        {
            var listOfNumbers = new List<int>();

            while (true)
            {
                Console.Write("Enter a positive number: ");
                var input = Console.ReadLine();

                if (input.Length < 1)
                {
                    break;
                }

                var number = int.Parse(input);
                listOfNumbers.Add(number);
            }

            if (listOfNumbers.Count > 0)
            {
                Console.WriteLine($"Sequence sum: {listOfNumbers.Sum(x => x)}");
                Console.WriteLine($"Sequence average: {listOfNumbers.Average(x => x):f2}");
            }
        }
    }
}
