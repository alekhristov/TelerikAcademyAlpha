using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_ShortestSequenceOfOperations
{
    class ShortestSequenceOfOperations
    {
        static void Main(string[] args)
        {
            var input = "5 16".Split().Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];
            var result = new Queue<int>();
            result.Enqueue(n);

            while (n != m)
            {
                n += 2;
                result.Enqueue(n);
                if (n == m) break;

                n += 1;
                result.Enqueue(n);
                if (n == m) break;

                n *= 2;
                result.Enqueue(n);
            }

            Console.WriteLine(string.Join(" -> ", result));
        }
    }
}
