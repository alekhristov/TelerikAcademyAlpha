using System;
using System.Linq;

namespace _04_LargestAreaInMatrix
{
    class MessagesInBottle
    {
        static int currentArea;
        static int largestArea;
        static int[] rows = new int[] { 1, -1, 0, 0 };
        static int[] cols = new int[] { 0, 0, 1, -1 };

        static void Main(string[] args)
        {
            var rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfRows = rowsCols[0];
            var numberOfCols = rowsCols[1];

            var matrix = new int[numberOfRows, numberOfCols];
            var visited = new bool[numberOfRows, numberOfCols];

            for (int row = 0; row < numberOfRows; row++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < numberOfCols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfCols; col++)
                {
                    if (!visited[row, col])
                    {
                        currentArea = 0;
                        Dfs(row, col, matrix, visited, matrix[row, col]);
                    }
                }
            }

            Console.WriteLine(largestArea);
        }

        private static void Dfs(int row, int col, int[,] matrix, bool[,] visited, int currentValue)
        {
            if (row < 0 || col < 0 || row > matrix.GetLength(0) - 1 || col > matrix.GetLength(1) - 1)
            {
                return;
            }
            if (matrix[row, col] != currentValue)
            {
                return;
            }
            if (visited[row, col])
            {
                return;
            }

            currentArea++;
            visited[row, col] = true;
            largestArea = largestArea < currentArea ? currentArea : largestArea;

            for (int move = 0; move < rows.Length; move++)
            {
                Dfs(row + rows[move], col + cols[move], matrix, visited, matrix[row, col]);
            }
        }
    }
}
