using System;

namespace _01_NesteLoops
{
    class NestedLoops
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            NestedLoopsRecursion(n, arr);
        }

        private static void NestedLoopsRecursion(int n, int[] arr, int start = 0)
        {
            if (start == n)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[start] = i;
                NestedLoopsRecursion(n, arr, start + 1);
            }
        }
    }
}
