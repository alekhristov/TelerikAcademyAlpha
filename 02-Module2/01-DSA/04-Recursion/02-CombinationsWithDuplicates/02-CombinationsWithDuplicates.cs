using System;

namespace _02_CombinationsWithDuplicates
{
    class CombinationsWithDuplicates
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var arr = new int[k];

            FindCombinationsWithDuplicates(n, k, arr);
        }

        private static void FindCombinationsWithDuplicates(int n, int k, int[] arr, int bottom = 0, int start = 1)
        {
            if (bottom == k)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                arr[bottom] = i;
                FindCombinationsWithDuplicates(n, k, arr, bottom + 1, i);
            }
        }
    }
}
