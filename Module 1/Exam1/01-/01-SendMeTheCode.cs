using System;
using System.Numerics;

namespace _01_
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var index = input.Length;
            var currentDigit = 0;
            BigInteger sum = 0;
            var result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    i++;
                    currentDigit = int.Parse(input[i].ToString()) * (-1);
                    index--;
                }
                if (char.IsDigit(input[i]))
                {
                    currentDigit = int.Parse(input[i].ToString());
                }
                if (index % 2 != 0)
                {
                    sum += currentDigit * index * index;
                }
                else
                {
                    sum += currentDigit * currentDigit * index;
                }
                index--;
            }
            BigInteger last = sum % 10;

            if (last == 0)
            {
                Console.WriteLine(sum);
                Console.WriteLine("Big Vik wins again!");
            }
            else
            {
                var start = (sum % 26) + 65;

                while (true)
                {
                    result += (char)start;
                    if (result.Length == last)
                    {
                        break;
                    }

                    start++;
                    if (start > 90)
                    {
                        start = 65;
                    }
                }
                Console.WriteLine(sum);
                Console.WriteLine(result);
            }
        }
    }
}
