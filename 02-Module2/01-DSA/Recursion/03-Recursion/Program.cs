using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[]
                {
                    2, 3, 4, 5, 6, 7, 8, 8, 9, 10, 12
                };
            var num = 3;

            Console.WriteLine(BinarySearch(arr, num));
        }

        public static int BinarySearch(int[] arr, int num)
        {
            var middleElement = arr[arr.Length / 2];
            var newArr = new int[(arr.Length) / 2];

            if (middleElement == num)
            {
                return Array.IndexOf(arr, num);
            }

            else if (middleElement < num)
            {
                var index = 0;
                for (int i = ((arr.Length - 1) / 2) + 1; i < arr.Length - 1; i++)
                {
                    newArr[index] = arr[i];
                    index++;
                }
            }

            else
            {
                for (int i = 0; i < ((arr.Length - 1) / 2) - 1; i++)
                {
                    newArr[i] = arr[i];
                }
            }
            return BinarySearch(newArr, num);
        }
    }
}