using System;

namespace _02_BinarySearch
{
    class Program
    {
        static int num;

        static void Main(string[] args)
        {
            var arrNumbers = new int[101];

            for (int i = 0; i <= 100; i++)
            {
                arrNumbers[i] = i;
            }

            //arrNumbers = arrNumbers.OrderBy(n => Guid.NewGuid()).ToArray();
            Console.WriteLine(BinarySearch(arrNumbers, 10));
        }

        public static int BinarySearch(int[] numbers, int value)
        {
            if (numbers.Length == 0)
            {
                return -1;
            }

            return BinarySearchInternal(value, 0, numbers.Length - 1, numbers);
        }

        private static int BinarySearchInternal(int value, int minIndex, int maxIndex, int[] arr)
        {
            if (minIndex > maxIndex)
            {
                return -1;
            }

            int midIndex = (minIndex + maxIndex) / 2;
            var midElement = arr[midIndex];

            if (midElement == value)
            {
                return midIndex;
            }

            if (midElement < value)
            {
                minIndex = midIndex + 1;
            }
            else if (midElement > value)
            {
                maxIndex = midIndex - 1;
            }

            return BinarySearchInternal(value, minIndex, maxIndex, arr);
        }
    }
}
