using System;
using System.Text;

namespace _02_Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower().ToCharArray();
            var sb = new StringBuilder();

            foreach (var c in input)
            {
                if (c >= 'a' && c <= 'z')
                {
                    sb.Append(c);
                }
            }
            var letters = sb.ToString();
            var leftSide = letters.Substring(0, letters.Length / 2);
            string rightSide;

            if (letters.Length % 2 == 0)
            {
                rightSide = letters.Substring(letters.Length / 2);
            }
            else
            {
                rightSide = letters.Substring(letters.Length / 2 + 1);
            }

            var diff = 0;

            for (int i = 0; i < leftSide.Length; i++)
            {
                var num1 = leftSide[i];
                var num2 = rightSide[leftSide.Length - 1 - i];

                if (num1 != num2)
                {
                    diff += Math.Min(Math.Abs(num1 - num2), 26 - (Math.Abs(num1 - num2)));
                }
            }

            Console.WriteLine(diff);
        }
    }
}
