using System;

namespace _13_ConvertDecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToBinary(66, string.Empty));
        }

        private static string ConvertToBinary(int num, string result)
        {
            if (num == 0)
            {
                var res = result.ToCharArray();
                Array.Reverse(res);
                return string.Join("", res);
            }

            result += num % 2;
            return ConvertToBinary(num / 2, result);
        }
    }
}
