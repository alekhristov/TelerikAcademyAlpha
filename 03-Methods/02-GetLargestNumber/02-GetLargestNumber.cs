using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_GetLargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var num1 = input[0];
            var num2 = input[1];
            var num3 = input[2];

            var largerNum = Math.Max(num1, num2);

            GetMax(num3, largerNum);
        }

        private static void GetMax(int num3, int largerNum)
        {
            var largestNum = Math.Max(num3, largerNum);
            Console.WriteLine(largestNum);
        }
    }
}
