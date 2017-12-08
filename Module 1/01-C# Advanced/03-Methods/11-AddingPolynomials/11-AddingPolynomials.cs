using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_AddingPolynomials
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            PrintAddedPolynomials(array1, array2, n);
        }

        private static void PrintAddedPolynomials(int[] array1, int[] array2, int n)
        {
            var result = new List<int>();

            for (int i = 0; i < n; i++)
            {
                result.Add(array1[i] + array2[i]);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
