using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_JediMeditation
{
    class JediMedidation
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var jedis = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            var mQueue = new Queue<string>();
            var kQueue = new Queue<string>();
            var pQueue = new Queue<string>();
            var result = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                var jediType = jedis[i][0];

                switch (jediType)
                {
                    case 'M': mQueue.Enqueue(jedis[i]);
                        break;
                    case 'K': kQueue.Enqueue(jedis[i]);
                        break;
                    case 'P': pQueue.Enqueue(jedis[i]);
                        break;
                    default:
                        break;
                }
            }

            foreach (var jedi in mQueue)
            {
                result.Enqueue(jedi);
            }
            foreach (var jedi in kQueue)
            {
                result.Enqueue(jedi);
            }
            foreach (var jedi in pQueue)
            {
                result.Enqueue(jedi);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
