using System;

namespace _02_PrintNumbersFromNTo1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbersFromNTo1(10, 1);
        }

        private static void PrintNumbersFromNTo1(int num, int end)
        {
            if (num < end)
            {
                return;
            }

            Console.WriteLine(num);
            PrintNumbersFromNTo1(num - 1, end);
        }
    }
}
