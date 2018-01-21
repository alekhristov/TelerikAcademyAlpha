using System;

namespace _09_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindFactorial(5));
        }

        private static int FindFactorial(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            var result = num * FindFactorial(num - 1);
            return result;
        }
    }
}
