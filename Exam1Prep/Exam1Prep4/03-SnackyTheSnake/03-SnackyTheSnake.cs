using System;
using System.Linq;

namespace _03_SnackyTheSnake
{
    class Program
    {
        static int startRow;
        static int startCol;
        static int snackyLength = 3;
        static int movesCount;
        static bool stop = false;

        static void Main(string[] args)
        {
            var denDimensions = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
            var matrix = new char[denDimensions[0], denDimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRow = Console.ReadLine().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                    if (matrix[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            var directions = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            for (int i = 0; i < directions.Length; i++)
            {
                movesCount++;

                switch (directions[i])
                {
                    case 'd':
                        startRow++;
                        if (startRow > matrix.GetLength(0) - 1)
                        {
                            Console.WriteLine("Snacky will be lost into the depths with length {0}", snackyLength);
                            return;
                        }
                        CheckWhatSnackyStepsOn(matrix);
                        break;
                    case 'u':
                        startRow--;
                        CheckWhatSnackyStepsOn(matrix);

                        break;
                    case 'l':
                        startCol--;
                        if (startCol < 0)
                        {
                            startCol = matrix.GetLength(1) - 1;
                        }
                        CheckWhatSnackyStepsOn(matrix);

                        break;
                    case 'r':
                        startCol++;
                        if (startCol > matrix.GetLength(1) - 1)
                        {
                            startCol = 0;
                        }
                        CheckWhatSnackyStepsOn(matrix);

                        break;
                    default:
                        break;
                }
                if (movesCount % 5 == 0)
                {
                    snackyLength--;

                    if (snackyLength <= 0)
                    {
                        Console.WriteLine("Snacky will starve at [{0},{1}]", startRow, startCol);
                        return;
                    }
                }
                if (stop == true)
                {
                    return;
                }
            }
            Console.WriteLine("Snacky will be stuck in the den at [{0},{1}]", startRow, startCol);
        }

        private static void CheckWhatSnackyStepsOn(char[,] matrix)
        {
            switch (matrix[startRow, startCol])
            {
                case '#':
                    Console.WriteLine("Snacky will hit a rock at [{0},{1}]", startRow, startCol);
                    stop = true;
                    return;
                case '*': snackyLength++;
                    matrix[startRow, startCol] = '.';
                    break;
                case 's':
                    Console.WriteLine("Snacky will get out with length {0}", snackyLength);
                    stop = true;
                    break;
                default:
                    break;
            }
        }
    }
}
