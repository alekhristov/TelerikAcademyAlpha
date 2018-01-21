using System;

namespace _05_CountNumberOfDigits
{
    class CountNumberOfDigits
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountDigits(12345));
        }

        private static int CountDigits(int n, int count = 0)
        {
            if (n == 0)
            {
                return count;
            }

            count++;
            return CountDigits(n / 10, count);
        }
    }
}
