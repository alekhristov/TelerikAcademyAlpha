using System;
using System.Linq;

namespace _02_MaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().ToArray();
            var n = int.Parse(size[0]);
            var m = int.Parse(size[1]);
            var matrix = new int[n, m];

            var maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 2, col + 2];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}