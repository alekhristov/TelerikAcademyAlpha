using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_RemoveNumbersByOddOccurence
{
    class RemoveNumbersByOddOccurence
    {
        static void Main(string[] args)
        {
            var listOfNumbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var newList = listOfNumbers.Distinct().ToList();

            foreach (var num in newList)
            {
                if (listOfNumbers.Where(n => n == num).Count() % 2 != 0)
                {
                    listOfNumbers.RemoveAll(n => n == num);
                }
            }

            Console.WriteLine(string.Join(", ", listOfNumbers));
        }
    }
}
