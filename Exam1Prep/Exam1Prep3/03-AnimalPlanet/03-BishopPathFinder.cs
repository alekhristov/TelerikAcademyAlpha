using System;
using System.Linq;

namespace _03_AnimalPlanet
{
    class Program
    {
        static long totalPoints;
        static int startRow;
        static int startCol;

        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[size[0], size[1]];
            startRow = matrix.GetLength(0) - 1;
            startCol = 0;

            var initialRow = matrix.GetLength(0) - 1;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (startRow - row) * 3 + col * 3;
                }
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var move = Console.ReadLine().Split().ToArray();
                var direction = move[0];
                var steps = int.Parse(move[1]);

                switch (direction)
                {
                    case "RU":
                        UpRight(matrix, steps);
                        break;
                    case "UR":
                        UpRight(matrix, steps);
                        break;
                    case "LU":
                        UpLeft(matrix, steps);
                        break;
                    case "UL":
                        UpLeft(matrix, steps);
                        break;
                    case "DL":
                        DownLeft(matrix, steps);
                        break;
                    case "LD":
                        DownLeft(matrix, steps);
                        break;
                    case "DR":
                        DownRight(matrix, steps);
                        break;
                    case "RD":
                        DownRight(matrix, steps);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(totalPoints);
        }

        private static void UpRight(int[,] matrix, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (startRow < 0 || startCol > matrix.GetLength(1) - 1)
                {
                    startRow++;
                    startCol--;
                    break;
                }
                totalPoints += matrix[startRow, startCol];
                matrix[startRow, startCol] = 0;
                if (i == steps - 1)
                {
                    break;
                }
                startRow--;
                startCol++;
            }
        }

        private static void UpLeft(int[,] matrix, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (startRow < 0 || startCol < 0)
                {
                    startRow++;
                    startCol++;
                    break;
                }
                totalPoints += matrix[startRow, startCol];
                matrix[startRow, startCol] = 0;
                if (i == steps - 1)
                {
                    break;
                }
                startRow--;
                startCol--;
            }
        }

        private static void DownLeft(int[,] matrix, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (startCol < 0 || startRow > matrix.GetLength(0) - 1)
                {
                    startRow--;
                    startCol++;
                    break;
                }
                totalPoints += matrix[startRow, startCol];
                matrix[startRow, startCol] = 0;
                if (i == steps - 1)
                {
                    break;
                }
                startRow++;
                startCol--;
            }
        }

        private static void DownRight(int[,] matrix, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (startRow > matrix.GetLength(0) - 1 || startCol > matrix.GetLength(1) - 1)
                {
                    startRow--;
                    startCol--;
                    break;
                }
                totalPoints += matrix[startRow, startCol];
                matrix[startRow, startCol] = 0;
                if (i == steps - 1)
                {
                    break;
                }
                startRow++;
                startCol++;
            }
        }
    }
}
