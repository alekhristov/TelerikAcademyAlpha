using System;
using System.Linq;

namespace _12_StackADT
{
    class StartUp
    {
        static void Main()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            Console.WriteLine(stack);

            stack.Push(2);
            Console.WriteLine(stack);

            stack.Push(3);
            Console.WriteLine(stack);

            Console.WriteLine($"Last: {stack.Peek()}");

            Console.WriteLine($"Count: {stack.Count}");
            Console.WriteLine($"Contains 2: {stack.Contains(2)}");

            Console.WriteLine($"Capacity: {stack.Capacity}");
            stack.TrimExcess();
            Console.WriteLine($"Capacity: {stack.Capacity}");

            while (stack.Count != 0)
            {
                Console.WriteLine($"Pop: {stack.Pop()}");
            }

            Console.WriteLine($"Count: {stack.Count}");

            try
            {
                stack.Clear();
                stack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                stack.Clear();
                stack.Peek();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}