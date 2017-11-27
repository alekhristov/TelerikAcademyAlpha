using System;
using System.Numerics;

namespace _10_NFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            PrintNFactorial(n);
        }

        private static void PrintNFactorial(long n)
        {
            BigInteger factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
