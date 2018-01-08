using System;
using System.Collections.Generic;

namespace _05_StackExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("1. Ivan");
            stack.Push("2. Nikolay");
            stack.Push("3. Mariya");
            stack.Push("4. George");

            Console.WriteLine($"Top = {stack.Peek()}");

            while (stack.Count > 0)
            {
                string personName = stack.Pop();
                Console.WriteLine(personName);
            }
        }
    }
}
