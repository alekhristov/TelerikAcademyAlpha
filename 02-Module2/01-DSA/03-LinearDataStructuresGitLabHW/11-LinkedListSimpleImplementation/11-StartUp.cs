using System;
using System.Linq;

namespace _11_LinkedListSimpleImplementation
{
    class StartUp
    {
        static void Main()
        {
            var list = new LinkedList<int>();

            list.AddLast(1);
            Console.WriteLine(list);

            list.AddLast(2);
            Console.WriteLine(list);

            list.AddLast(3);
            Console.WriteLine(list);

            list.AddFirst(-1);
            Console.WriteLine(list);

            list.AddFirst(-2);
            Console.WriteLine(list);

            list.AddFirst(-3);
            Console.WriteLine(list);

            Console.WriteLine($"Remove First: { list.RemoveFirst().Value}");
            Console.WriteLine($"Remove Last: {list.RemoveLast().Value}");
            Console.WriteLine(list);

            Console.WriteLine($"Min: {list.Min()}; Max: {list.Max()}");
            Console.WriteLine($"Contains 2: {list.Contains(2)}");
            Console.WriteLine($"Count: {list.Count}");
        }
    }
}