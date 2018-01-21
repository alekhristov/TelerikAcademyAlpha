using System;

namespace _11_FindGCDAndLCM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"GCD = {GCD(10, 15)}");

            Console.WriteLine($"LCM = {LCM(10, 15)}");
            
        }

        private static int LCM(int num1, int num2, int start = 15)
        {
            if (start % num1 == 0 && start % num2 == 0)
            {
                return start;
            }

            return LCM(num1, num2, start + 1);
        }

        private static int GCD(int num1, int num2, int start = 10)
        {
            if (num1 % start == 0 && num2 % start == 0)
            {
                return start;
            }

            return GCD(num1, num2, start - 1);
        }
    }
}
