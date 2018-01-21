using System;
using System.Text;

namespace _04_Permutations
{
    class Permutations
    {
        static StringBuilder sb;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[3];
            sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            FindAllPermutations(n, arr);
            Console.WriteLine(sb.ToString().TrimEnd(", ".ToCharArray()));
        }

        private static void FindAllPermutations(int n, int[] arr)
        {
            if (n == 1)
            {
                sb.Append(($"{{{string.Join(", ", arr)}}}, "));
                return;
            }

            for (int i = 0; i < n - 1; i++)
            {
                FindAllPermutations(n - 1, arr);

                if (n % 2 == 0)
                {
                    var temp = arr[n - 1];
                    arr[n - 1] = arr[i];
                    arr[i] = temp;
                }
                else
                {
                    var temp = arr[n - 1];
                    arr[n - 1] = arr[0];
                    arr[0] = temp;
                }
            }
            FindAllPermutations(n - 1, arr);
        }
    }
}
