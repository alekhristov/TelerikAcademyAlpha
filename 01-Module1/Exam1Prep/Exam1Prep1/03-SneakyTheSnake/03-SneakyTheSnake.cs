using System;
using System.Linq;

namespace _03_SneakyTheSnake
{
    class Program
    {
        static int snakeSize = 3;
        static bool stop = false;
        static int startRow = 0;
        static int startCol = 0;

        static void Main(string[] args)
        {
            var denSize = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
            var matrix = new char[denSize[0], denSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (inputRow[col] == 'e')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            var directions = Console.ReadLine().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            var counter = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                counter++;
                if (counter % 5 == 0)
                {
                    snakeSize--;
                    counter = 0;

                    if (snakeSize <= 0)
                    {
                        Console.WriteLine("Sneaky is going to starve at [{0},{1}]", startRow, startCol);
                        return;
                    }
                }

                switch (directions[i])
                {
                    case "s":
                        startRow++;
                        CheckWhatFollowsNext(matrix); break;
                    case "a":
                        startCol--;
                        CheckWhatFollowsNext(matrix); break;
                    case "d":
                        startCol++;
                        CheckWhatFollowsNext(matrix); break;
                    case "w":
                        startRow--;
                        CheckWhatFollowsNext(matrix); break;
                    default:
                        break;
                }
                if (stop)
                {
                    return;
                }
            }
            Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", startRow, startCol);

        }

        private static void CheckWhatFollowsNext(char[,] matrix)
        {
            if (startCol > matrix.GetLength(1) - 1)
            {
                startCol = 0;
            }
            else if (startCol < 0)
            {
                startCol = matrix.GetLength(1) - 1;
            }
            else if (startRow > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", snakeSize);
                stop = true;
                return;
            }
            if (matrix[startRow, startCol] == '@')
            {
                snakeSize++;
                matrix[startRow, startCol] = '-';
            }
            else if (matrix[startRow, startCol] == '%')
            {
                Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", startRow, startCol);
                stop = true;
            }
            else if (matrix[startRow, startCol] == 'e')
            {
                Console.WriteLine("Sneaky is going to get out with length {0}", snakeSize);
                stop = true;
            }
        }
    }
}
