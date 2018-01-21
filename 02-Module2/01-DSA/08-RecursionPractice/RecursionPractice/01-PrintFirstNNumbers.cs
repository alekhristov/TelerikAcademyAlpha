using System;

namespace RecursionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers(1, 10);
        }

        private static void PrintNumbers(int start, int num)
        {
            if (start > num)
            {
                return;
            }

            Console.WriteLine(start);
            PrintNumbers(start + 1, num);
        }
    }
}
