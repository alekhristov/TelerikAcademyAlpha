using System;

namespace _07_ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine();

            PrintReversedNumber(number);
        }

        private static void PrintReversedNumber(string number)
        {
            var result = string.Empty;
            for (int i = number.Length-1; i >= 0; i--)
            {
                result += number[i];
            }
            Console.WriteLine(result);
        }
    }
}
