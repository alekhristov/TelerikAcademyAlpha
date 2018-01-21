using System;

namespace _06_PrintEvenOrOddNumbers
{
    class PrintEvenOrOdd
    {
        static void Main(string[] args)
        {
            PrintEvenOrOddNums(20);
            Console.WriteLine();
        }

        private static void PrintEvenOrOddNums(int num, int start = 1)
        {
            if (start > num)
            {
                return;
            }

            if (start % 2 == 0)
            {
                Console.Write(start + " ");
            }
            PrintEvenOrOddNums(num, start + 1);
        }
    }
}
