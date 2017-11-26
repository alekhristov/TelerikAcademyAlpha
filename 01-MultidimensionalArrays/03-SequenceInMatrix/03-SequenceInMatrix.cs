using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _03_SequenceInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = matrixSize[0];
            var m = matrixSize[1];
            var matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                var inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }
            var rows = 0;
            var cols = 0;
            var counter = 0;
            var list = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var currentNumber = matrix[i, j];

                    if (i > 0 && j > 0)
                    {
                        var previousNumber = matrix[i - 1, j - 1];
                        if (currentNumber == previousNumber)
                        {
                            if (list.Contains(currentNumber))
                            {
                                list.Add(matrix[i, j]);
                            }
                            else
                            {
                                list.Add(previousNumber);
                                list.Add(currentNumber);
                            }
                        }
                    }
                }

            }
        }
    }
}
