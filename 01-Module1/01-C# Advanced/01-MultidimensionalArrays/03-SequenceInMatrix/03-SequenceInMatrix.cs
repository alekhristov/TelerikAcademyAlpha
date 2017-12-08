using System;
using System.Linq;

namespace MaxSequenceInAnArray
{
    class MaxSequence
    {
        static void Main()
        {
            string dimensions = Console.ReadLine();
            string[] dim = dimensions.Split(' ');
            int rows = int.Parse(dim[0]);
            int cols = int.Parse(dim[1]);

            int[,] array = new int[rows, cols];

            FillingTheMatrix(array, rows, cols);
            Console.WriteLine(LoopingThroughTheMatrix(array, array.GetLength(0), array.GetLength(1)));


        }

        static void FillingTheMatrix(int[,] array, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = int.Parse(line[j]);
                }
            }
        }


        //the same result could be achieved with half of the methods (not duplicating directions)
        static int Forward(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currCol < array.GetLength(1) && array[currRow, currCol] == num)
            {
                count++;
                currCol++;
            }
            return count;
        }
        static int Backwards(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currCol > -1 && array[currRow, currCol] == num)
            {
                count++;
                currCol--;
            }
            return count;
        }
        static int Up(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currRow > -1 && array[currRow, currCol] == num)
            {
                count++;
                currRow--;
            }
            return count;
        }
        static int Down(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currRow < array.GetLength(0) && array[currRow, currCol] == num)
            {
                count++;
                currRow++;
            }
            return count;
        }
        static int UpLeft(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currRow > -1 && currCol > -1 && array[currRow, currCol] == num)
            {
                count++;
                currCol--;
                currRow--;
            }
            return count;
        }
        static int UpRight(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currCol < array.GetLength(1) && currRow > -1 && array[currRow, currCol] == num)
            {
                count++;
                currRow--;
                currCol++;
            }
            return count;
        }
        static int DownLeft(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currCol > -1 && currRow < array.GetLength(0) && array[currRow, currCol] == num)
            {
                count++;
                currRow++;
                currCol--;
            }
            return count;
        }
        static int DownRight(int[,] array, int num, int currRow, int currCol)
        {
            int count = 0;
            while (currRow < array.GetLength(0) && currCol < array.GetLength(1) && array[currRow, currCol] == num)
            {
                count++;
                currRow++;
                currCol++;
            }
            return count;
        }

        static int LoopingThroughTheMatrix(int[,] array, int rows, int cols)
        {
            int max = -1;
            int count = -1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int num = array[i, j];
                    int[] results = new int[8] { Forward(array, num, i, j),
                                                Backwards(array, num, i, j),
                                                Up(array, num, i, j),
                                                Down(array, num, i, j),
                                                UpLeft(array, num, i, j),
                                                UpRight(array, num, i, j),
                                                DownLeft(array, num, i, j),
                                                DownRight(array, num, i, j)
                    };
                    count = results.Max();
                    if (count > max)
                    {
                        max = count;
                    }
                }

            }
            return max;
        }
    }
}