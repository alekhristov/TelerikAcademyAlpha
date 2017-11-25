using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CorrectBracketsTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var openBracketCount = 0;
            var closeBracketCount = 0;

            foreach (var item in input)
            {
                if (item == '(')
                {
                    openBracketCount++;
                }
                else if (item == ')')
                {
                    closeBracketCount++;
                }
            }

            if (closeBracketCount != openBracketCount)
            {
                Console.WriteLine("Incorrect");
            }
            else
            {
                Console.WriteLine("Correct");
            }
        }
    }
}
