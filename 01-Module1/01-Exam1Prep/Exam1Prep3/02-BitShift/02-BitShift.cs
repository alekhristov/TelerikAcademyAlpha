using System;
using System.Linq;
using System.Numerics;

namespace _02_BitShift
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var path = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new BigInteger[r, c];
            BigInteger sum = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                var power = matrix.GetLength(0) - 1 - row;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (BigInteger)Math.Pow(2, power);
                    power++;
                }
            }
            var startRow = matrix.GetLength(0) - 1;
            var startCol = 0;

            for (int i = 0; i < n; i++)
            {
                var code = path[i];
                var coef = Math.Max(r, c);
                var row = code / coef;
                var col = code % coef;
                var colSteps = Math.Abs(startCol - col);
                var rowSteps = Math.Abs(startRow - row);

                for (int j = 0; j <= colSteps; j++)
                {
                    if (startCol > col)
                    {
                        sum += matrix[startRow, startCol];
                        matrix[startRow, startCol] = 0;
                        startCol--;
                    }
                    else
                    {
                        sum += matrix[startRow, startCol];
                        matrix[startRow, startCol] = 0;
                        startCol++;
                    }
                }
                startCol = col;

                for (int j = 0; j <= rowSteps; j++)
                {
                    if (startRow > row)
                    {
                        sum += matrix[startRow, startCol];
                        matrix[startRow, startCol] = 0;
                        startRow--;
                    }
                    else
                    {
                        sum += matrix[startRow, startCol];
                        matrix[startRow, startCol] = 0;
                        startRow++;
                    }
                }
                startRow = row;
            }
            Console.WriteLine(sum);
        }
    }
}
