using System;
using System.Collections.Generic;

namespace _09_SequenceOf50Elements
{
    class SequenceOf50Elements
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            var result = new Queue<int>();
            queue.Enqueue(n);
            result.Enqueue(n);

            while (true)
            {
                var currentNum = queue.Dequeue();

                result.Enqueue(currentNum + 1);
                if (result.Count == 50) break;
                queue.Enqueue(currentNum + 1);

                result.Enqueue((2 * currentNum) + 1);
                if (result.Count == 50) break;
                queue.Enqueue((2 * currentNum) + 1);

                result.Enqueue(currentNum + 2);
                if (result.Count == 50) break;
                queue.Enqueue(currentNum + 2);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
