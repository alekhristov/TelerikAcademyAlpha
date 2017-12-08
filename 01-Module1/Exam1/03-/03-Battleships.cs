using System;
using System.Linq;

namespace _03_
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix1 = new int[size[0], size[1]];
            var matrix2 = new int[size[0], size[1]];
            var p1Score = 0;
            var p2Score = 0;
            var row2 = matrix2.GetLength(0) - 1;

            for (int i = 0; i < 2 * size[0]; i++)
            {
                var cells = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i < size[0])
                {
                    for (int col = 0; col < matrix1.GetLength(1); col++)
                    {
                        matrix1[i, col] = cells[col];
                        if (cells[col] == 1)
                        {
                            p1Score++;
                        }
                    }

                }
                else
                {
                    for (int col = 0; col < matrix1.GetLength(1); col++)
                    {
                        matrix2[row2, col] = cells[col];
                        if (cells[col] == 1)
                        {
                            p2Score++;
                        }
                    }
                    row2--;
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split().ToArray();
                if (command[0] == "END")
                {
                    break;
                }

                var player = command[0];
                var attackRow = int.Parse(command[1]);
                var attackCol = int.Parse(command[2]);

                if (player == "P1")
                {
                    if (matrix2[attackRow, attackCol] == 1)
                    {
                        Console.WriteLine("Booom");
                        matrix2[attackRow, attackCol] = 5;
                        p2Score--;
                    }
                    else if (matrix2[attackRow, attackCol] == 0)
                    {
                        Console.WriteLine("Missed");
                        matrix2[attackRow, attackCol] = 5;
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else if (player == "P2")
                {
                    if (matrix1[attackRow, attackCol] == 1)
                    {
                        Console.WriteLine("Booom");
                        matrix1[attackRow, attackCol] = 5;
                        p1Score--;
                    }
                    else if (matrix1[attackRow, attackCol] == 0)
                    {
                        Console.WriteLine("Missed");
                        matrix1[attackRow, attackCol] = 5;
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
            }
            Console.WriteLine($"{p1Score}:{p2Score}");
        }
    }
}
