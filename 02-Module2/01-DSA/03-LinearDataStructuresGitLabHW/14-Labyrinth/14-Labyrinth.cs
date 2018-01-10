using System;
using System.Collections.Generic;
using System.Text;

namespace _14.Labyrinth
{
    class Labyrinth
    {
        static void Main()
        {
            string[,] labyrinth = {
                                      {"0", "0", "0", "x", "0", "x"},
                                      {"0", "x", "0", "x", "0", "x"},
                                      {"0", "*", "x", "0", "x", "0"},
                                      {"0", "x", "0", "0", "0", "0"},
                                      {"0", "0", "0", "x", "x", "0"},
                                      {"0", "0", "0", "x", "0", "x"},
                                  };
            Console.WriteLine(PrintLabyrinth(labyrinth));
            string[,] solvedLabyrinth = SolveLabyrinth(labyrinth);
            Console.WriteLine();
            Console.WriteLine(PrintLabyrinth(solvedLabyrinth));
        }

        private static string[,] SolveLabyrinth(string[,] labyrinth)
        {
            int startX = 0;
            int startY = 0;

            if (GetEntryPoint(labyrinth, out startX, out startY))
            {
                Queue<MatrixItem> q = new Queue<MatrixItem>();
                labyrinth[startX, startY] = "0";
                MatrixItem item = new MatrixItem(startX, startY, int.Parse(labyrinth[startX, startY]));
                q.Enqueue(item);
                while (q.Count > 0)
                {
                    MatrixItem newItem = new MatrixItem(q.Dequeue());
                    labyrinth[newItem.X, newItem.Y] = newItem.Value.ToString();
                    newItem.Value++;

                    if (((newItem.X - 1) >= 0) &&
                        (labyrinth[newItem.X - 1, newItem.Y] == "0"))
                    {
                        MatrixItem itemOne = new MatrixItem(newItem.X - 1, newItem.Y, newItem.Value);
                        q.Enqueue(itemOne);
                    }
                    if ((newItem.X + 1 < labyrinth.GetLength(0)) &&
                        (labyrinth[newItem.X + 1, newItem.Y] == "0"))
                    {
                        MatrixItem itemTwo = new MatrixItem(newItem.X + 1, newItem.Y, newItem.Value);
                        q.Enqueue(itemTwo);
                    }
                    if ((newItem.Y - 1 >= 0) &&
                        (labyrinth[newItem.X, newItem.Y - 1] == "0"))
                    {
                        MatrixItem itemThree = new MatrixItem(newItem.X, newItem.Y - 1, newItem.Value);
                        q.Enqueue(itemThree);
                    }
                    if ((newItem.Y + 1 < labyrinth.GetLength(1)) &&
                        (labyrinth[newItem.X, newItem.Y + 1] == "0"))
                    {
                        MatrixItem itemFour = new MatrixItem(newItem.X, newItem.Y + 1, newItem.Value);
                        q.Enqueue(itemFour);
                    }
                }
                labyrinth[startX, startY] = "*";

                UnreachableCellsCalc(labyrinth);
            }
            else
            {
                throw new ArgumentException("No entry point");
            }

            return labyrinth;
        }


        private static bool GetEntryPoint(string[,] labyrinth, out int startX, out int startY)
        {
            startX = 0;
            startY = 0;
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startX = row;
                        startY = col;
                        return true;
                    }
                }
            }
            return false;
        }

        private static void UnreachableCellsCalc(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }
        }

        private static string PrintLabyrinth(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sb.Append(labyrinth[row, col]);
                    sb.Append(" ");
                }
                sb.Append("\n\r");
            }
            return sb.ToString();
        }
    }
}