namespace FillTheMatrix
{
    using System;

    class FillTheMatrix
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var c = char.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            var counter = 1;

            switch (c)
            {
                case 'a': MatrixA(n, matrix, counter); break;
                case 'b': MatrixB(n, matrix, counter); break;
                case 'c': MatrixC(n, matrix, counter); break;
                case 'd': MatrixD(n, matrix, counter); break;

                default:
                    break;
            }

            PrintMatrix(matrix);
        }

        private static void MatrixA(int n, int[,] matrix, int counter)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix[col, row] = counter;
                    counter++;
                }
            }
        }

        private static void MatrixB(int n, int[,] matrix, int counter)
        {
            for (int row = 0; row < n; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < n; col++)
                    {
                        matrix[col, row] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int col = n - 1; col >= 0; col--)
                    {
                        matrix[col, row] = counter;
                        counter++;
                    }
                }
            }
        }

        private static void MatrixC(int n, int[,] matrix, int counter)
        {
            for (int i = 0; i <= n * 2 - 1; i++)
            {
                int row;
                int col;

                if (i < n)
                {
                    row = n - 1 - i;
                    col = 0;

                    for (int j = 0; j <= i; j++)
                    {
                        matrix[row, col] = counter;
                        counter++;

                        row++;
                        col++;
                    }
                }
                else
                {
                    row = 0;
                    col = i - n + 1;

                    for (int j = 0; j < n * 2 - 1 - i; j++)
                    {
                        matrix[row, col] = counter;
                        counter++;

                        row++;
                        col++;
                    }
                }
            }
        }

        private static void MatrixD(int n, int[,] matrix, int counter)
        {
            var direction = "down";
            var position = new int[2] { 0, 0 };
            var row = position[0];
            var col = position[1];

            for (int i = 0; i < n * n; i++)
            {
                matrix[row, col] = counter;
                counter++;

                switch (direction)
                {
                    case "down":
                        if (row + 1 < n && matrix[row + 1, col] == 0)
                        {
                            row++;
                        }
                        else
                        {
                            direction = "right";
                            col++;
                        }
                        break;

                    case "right":
                        if (col + 1 < n && matrix[row, col + 1] == 0)
                        {
                            col++;
                        }
                        else
                        {
                            direction = "up";
                            row--;
                        }
                        break;

                    case "up":
                        if (row > 0 && matrix[row - 1, col] == 0)
                        {
                            row--;
                        }
                        else
                        {
                            direction = "left";
                            col--;
                        }
                        break;

                    case "left":
                        if (col > 0 && matrix[row, col - 1] == 0)
                        {
                            col--;
                        }
                        else
                        {
                            direction = "down";
                            row++;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[row, col]);
                        break;
                    }
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}