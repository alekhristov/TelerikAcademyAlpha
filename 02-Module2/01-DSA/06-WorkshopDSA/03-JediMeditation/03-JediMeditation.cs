using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var jedis = Console.ReadLine().Split().ToArray();
            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padawns = new Queue<string>();
            //var result = new Queue<string>();

            foreach (var jedi in jedis)
            {
                switch (jedi[0])
                {
                    case 'M': masters.Enqueue(jedi); break;
                    case 'K': knights.Enqueue(jedi); break;
                    case 'P': padawns.Enqueue(jedi); break;
                    default:
                        break;
                }
            }

            //foreach (var master in masters)
            //{
            //    result.Enqueue(master);
            //}
            //foreach (var knight in knights)
            //{
            //    result.Enqueue(knight);
            //}
            //foreach (var padawn in padawns)
            //{
            //    result.Enqueue(padawn);
            //}

            Console.WriteLine(string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", padawns));
        }
    }
}
