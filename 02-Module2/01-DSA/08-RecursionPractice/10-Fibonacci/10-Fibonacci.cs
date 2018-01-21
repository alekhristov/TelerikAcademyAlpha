using System;

namespace _10_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFibonacci(10));
        }

        private static int GetFibonacci(int num)
        {
            if (num == 1 || num == 2)
            {
                return 1;
            }

            var result = GetFibonacci(num - 1) + GetFibonacci(num - 2);
            return result;
        }
    }
}
