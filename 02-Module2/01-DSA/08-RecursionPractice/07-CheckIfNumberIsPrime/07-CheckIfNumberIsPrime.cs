using System;

namespace _07_CheckIfNumberIsPrime
{
    class CheckIfNumberIsPrime
    {
        static void Main(string[] args)
        {
            if (CheckIfPrimeNumber(9))
            {
                Console.WriteLine("Number is prime!");
            }
            else
            {
                Console.WriteLine("Number is not prime!");
            }
        }

        private static bool CheckIfPrimeNumber(int num, int start = 2)
        {
            if (start > Math.Sqrt(num))
            {
                return true;
            }

            if (num % start == 0)
            {
                return false;
            }

            return CheckIfPrimeNumber(num, start + 1);
        }
    }
}
