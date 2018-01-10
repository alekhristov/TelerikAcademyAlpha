using System;
using System.Linq;

namespace _13_QueueADT
{
    class StartUp
    {
        static void Main()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            Console.WriteLine(queue);

            queue.Enqueue(2);
            Console.WriteLine(queue);

            queue.Enqueue(3);
            Console.WriteLine(queue);

            Console.WriteLine(queue.ToString());
            Console.WriteLine($"First: {queue.Peek()}");

            Console.WriteLine($"Count: {queue.Count}");
            Console.WriteLine($"Contains 2: {queue.Contains(2)}");

            while (queue.Count != 0)
            {
                Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            }

            Console.WriteLine($"Count: {queue.Count}");

            try
            {
                queue.Clear();
                queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                queue.Clear();
                queue.Peek();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}