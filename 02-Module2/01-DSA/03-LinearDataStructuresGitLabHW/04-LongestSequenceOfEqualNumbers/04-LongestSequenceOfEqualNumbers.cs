using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_LongestSequenceOfEqualNumbers
{
    class LongestSequenceOfEqualNumbers
    {
        static void Main(string[] args)
        {
            var listOfNumbers = new List<int>() { 1, 2, 3, 4, 5, 5, 6, 6, 3, 3, 3, 3, 3, 4, 4, 4, 5 };
            
            FindTheLongestSequenceOfEqualNums(listOfNumbers);
        }

        private static void FindTheLongestSequenceOfEqualNums(List<int> listOfNumbers)
        {
            var count = 1;
            var maxCount = 1;
            var num = 0;
            var sequence = new List<int>();

            for (int i = 0; i < listOfNumbers.Count - 1; i++)
            {
                if (listOfNumbers[i] == listOfNumbers[i+1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                    continue;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    num = listOfNumbers[i];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                sequence.Add(num);
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
