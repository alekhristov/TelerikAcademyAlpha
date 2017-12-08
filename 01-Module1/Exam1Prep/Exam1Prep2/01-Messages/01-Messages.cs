using System;
using System.Numerics;

namespace _01_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine();
            var oper = char.Parse(Console.ReadLine());
            var inpu2 = Console.ReadLine();

            var num1 = BigInteger.Parse(Encode(input1));
            var num2 = BigInteger.Parse(Encode(inpu2));
            BigInteger result = 0;

            if (oper == '-')
            {
                result = num1 - num2;
            }
            else if (oper == '+')
            {
                result = num1 + num2;
            }
            
            var encodedResult = result.ToString()
                .Replace("0", "cad")
                .Replace("1", "xoz")
                .Replace("2", "nop")
                .Replace("3", "cyk")
                .Replace("4", "min")
                .Replace("5", "mar")
                .Replace("6", "kon")
                .Replace("7", "iva")
                .Replace("8", "ogi")
                .Replace("9", "yan");

            Console.WriteLine(encodedResult);
        }

        private static string Encode(string num)
        {
            return num = num
                .Replace("cad", "0")
                .Replace("xoz", "1")
                .Replace("nop", "2")
                .Replace("cyk", "3")
                .Replace("min", "4")
                .Replace("mar", "5")
                .Replace("kon", "6")
                .Replace("iva", "7")
                .Replace("ogi", "8")
                .Replace("yan", "9");
        }
    }
}
