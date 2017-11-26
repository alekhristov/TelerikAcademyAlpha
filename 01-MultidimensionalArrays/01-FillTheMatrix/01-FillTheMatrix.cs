using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var character = char.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            var counter = 1;

            int[,] matrix = new int[n, n];

            if (character == 'a')
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[col, row] = counter;
                        counter++;
                    }
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    var line = string.Empty;
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        line += matrix[row, col] + " ";
                    }
                    sb.AppendLine(line.TrimEnd());
                }
                Console.Write(sb);
            }
            else if (character == 'b')
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row % 2 == 0)
                        {
                            matrix[col, row] = counter;
                            counter++;
                        }
                        else
                        {
                            matrix[n - col - 1, row] = counter;
                            counter++;
                        }
                    }
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    var line = string.Empty;
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        line += matrix[row, col] + " ";
                    }
                    sb.AppendLine(line.TrimEnd());
                }
                Console.Write(sb);
            }
            else if (character == 'c')
            {
                var rows = 0;
                var cols = 0;

                //populate values under the main diagonal
                for (int i = n - 1; i >= 0; i--)
                {
                    rows = i;
                    cols = 0;
                    while (rows < n && cols < n)
                    {
                        matrix[rows, cols] = counter;

                        rows++;
                        cols++;
                        counter++;
                    }
                }

                //populate values over the main diagonal
                for (int i = 1; i < n; i++)
                {
                    rows = i;
                    cols = 0;
                    while (rows < n && cols < n)
                    {
                        matrix[cols, rows] = counter;

                        cols++;
                        rows++;
                        counter++;
                    }
                }

                for (rows = 0; rows < n; rows++)
                {
                    var line = string.Empty;
                    for (cols = 0; cols < n; cols++)
                    {
                        line += matrix[rows, cols] + " ";
                    }
                    sb.AppendLine(line.TrimEnd());
                }
                Console.Write(sb);

            }
            else if (character == 'd')
            {
                for (int i = 0; i < n; i++) // get top rows and cols
                {
                    for (int j = i; j < n - i; j++)
                    {
                        matrix[i, j] = counter;
                        counter++;
                    }

                    for (int j = 0; j < n - 1 - i * 2; j++) // get right coloumns 
                    {
                        matrix[j + 1 + i, n - i - 1] = counter;
                        counter++;
                    }


                    for (int j = 0; j < n - 1 - i * 2; j++) // get botom rows and cols
                    {
                        matrix[n - 1 - i, n - j - 2 - i] = counter;
                        counter++;
                    }


                    for (int j = 0; j < n - 2 - i * 2; j++) //get left cols
                    {
                        matrix[n - j - 2 - i, i] = counter;
                        counter++;
                    }
                }


                for (int row = 0; row < n; row++) // print
                {
                    var line = string.Empty;

                    for (int col = 0; col < n; col++)
                    {
                        line += matrix[col, row] + " "; 
                    }
                    sb.AppendLine(line.TrimEnd());
                }
                Console.Write(sb);
            }
        }
    }
}
