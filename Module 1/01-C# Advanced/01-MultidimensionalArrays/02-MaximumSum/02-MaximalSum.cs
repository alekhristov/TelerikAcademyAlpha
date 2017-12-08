using System;
using System.Linq;

namespace _02_MaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRow = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            FindMaximalSumInASquare(matrix);
        }

        private static void FindMaximalSumInASquare(int[,] matrix)
        {
            var maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                   var sum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 2, col + 2];

                    maxSum = sum > maxSum ? sum : maxSum;
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}