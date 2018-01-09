using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_SortNumbersInIncreasingOrder
{
    class SortNumbersInIncreasingOrder
    {
        static void Main(string[] args)
        {
            var listOfNumbers = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input.Length < 1)
                {
                    break;
                }

                listOfNumbers.Add(int.Parse(input));
            }

            if (listOfNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", listOfNumbers.OrderBy(n => n)));
            }
        }
    }
}
