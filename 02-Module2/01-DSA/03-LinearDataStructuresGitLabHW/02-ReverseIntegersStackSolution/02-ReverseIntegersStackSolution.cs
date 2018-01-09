using System;
using System.Collections.Generic;

namespace _02_ReverseIntegersStackSolution
{
    class ReverseIntegersStackSolution
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }
         
            //Console.WriteLine(string.Join(" ", stack));

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
