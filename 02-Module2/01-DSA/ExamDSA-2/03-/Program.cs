using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_
{
    class Program
    {
        static int count;
        static int[] used;
        static int numberOfBags = 1;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = input[0];
            var k = input[1];

            var bags = Console.ReadLine().Split().Select(int.Parse).ToArray();

            used = new int[k];

            Recursion(n, bags);
        }

        private static void Recursion(int n, int[] bags)
        {
            for (int i = 0; i < bags.Length; i++)
            {
                if (used[i] == int.MinValue)
                {
                    return;
                }
                if (n % bags[i] != 0)
                {
                    return;
                }

                count += numberOfBags;
                numberOfBags = n / bags[i];
                n /= numberOfBags;
                used[i] = int.MinValue;

                Recursion(n, bags);
            }
        }
    }
}
