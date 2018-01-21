using System;
using System.Linq;

namespace _01_SortingAlgorithms
{
    class SelectionSorter
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var arr = Enumerable.Range(1, 100).Select(x => random.Next(0, 101)).ToArray();
            var min = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(arr, i, min);
                }
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void Swap(int[] arr, int n1, int n2)
        {
            var temp = arr[n1];
            arr[n1] = arr[n2];
            arr[n2] = temp;
        }
    }
}
