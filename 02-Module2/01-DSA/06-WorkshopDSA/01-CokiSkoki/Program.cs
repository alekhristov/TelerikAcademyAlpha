using System;
using System.Linq;

namespace Coki_Skoki
{
    class StartUp
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var buildings = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var jumps = new int[N];

            for (int i = N - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (buildings[j] > buildings[i])
                    {
                        jumps[i] = jumps[j] + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(jumps.Max());
            Console.WriteLine(string.Join(" ", jumps));
        }
    }
}