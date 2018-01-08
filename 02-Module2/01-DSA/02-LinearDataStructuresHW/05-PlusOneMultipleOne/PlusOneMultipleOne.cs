using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_PlusOneMultipleOne
{
    class PlusOneMultipleOne
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];
            var queue = new Queue<int>();

            queue.Enqueue(n);
            int index = 0;

            while (queue.Count > 0)
            {
                int currentNum = queue.Dequeue();
                index++;

                if (index == m)
                {
                    Console.WriteLine(currentNum);
                    break;
                }
                queue.Enqueue(currentNum + 1);
                queue.Enqueue((2 * currentNum) + 1);
                queue.Enqueue(currentNum + 2);
            }
        }
    }
}
