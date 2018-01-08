using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            var expression = "1+(2-(2+3)*4/(3+1))*5";
            var stack = new Stack<int>();
            var result = new List<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    var startIndex = stack.Pop();
                    result.Add(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
            Console.WriteLine(string.Join("|", result));

            if (!stack.Any())
            {
                Console.WriteLine("The brackets are balanced");
            }

            while (stack.Any())
            {
                Console.WriteLine("Missing ) at end");
                stack.Pop();
            }
        }
    }
}
