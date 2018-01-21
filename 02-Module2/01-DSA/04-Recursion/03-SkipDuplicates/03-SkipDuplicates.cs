using System;

namespace _03_SkipDuplicates
{
    class SkipDuplicates
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var arr = new int[k];
            var used = new bool[n+1];

            FindAllNonDuplicates(n, k, arr, used);
        }

        private static void FindAllNonDuplicates(int n, int k, int[] arr, bool[] used, int bottom = 0, int start = 1)
        {
            if (bottom == k)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    arr[bottom] = i;
                    FindAllNonDuplicates(n, k, arr, used, bottom + 1, i);
                    used[i] = false;
                }
            }
        }
    }
}
