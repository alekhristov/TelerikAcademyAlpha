using System;

namespace _04_GetIndividualDigitsOfANumber
{
    class GetDigitsOfANumber
    {
        static void Main(string[] args)
        {
            GetDigits(1234);
            Console.WriteLine();
        }

        private static void GetDigits(int num)
        {
            if (num == 0)
            {
                return;
            }

            GetDigits(num / 10);
            Console.Write(num % 10 + " ");
        }
    }
}
