using System;
using System.Linq;

namespace _01_Kitty
{
    class Program
    {
        static int soulsCount;
        static int foodCount;
        static int deadlocksCount;
        static long currentPosition;
        static bool deadlocked;
        static int jumps;
        static string input = Console.ReadLine();
        static char[] field = input.ToCharArray();

        static void Main(string[] args)
        {
            var kittyPath = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            WhatKittyDoesNext(field[0], 0);

            if (deadlocked == true)
            {
                return;
            }

            for (int i = 0; i < kittyPath.Length; i++)
            {
                var nextPosition = currentPosition + kittyPath[i];
                currentPosition = nextPosition;

                while (nextPosition < 0)
                {
                    nextPosition += field.Length;
                }
                while (nextPosition > field.Length - 1)
                {
                    nextPosition -= field.Length;
                }

                jumps++;
                WhatKittyDoesNext(field[nextPosition], nextPosition);
                if (deadlocked == true)
                {
                    return;
                }
            }
            if (!deadlocked)
            {
                Console.WriteLine($"Coder souls collected: {soulsCount}");
                Console.WriteLine($"Food collected: {foodCount}");
                Console.WriteLine($"Deadlocks: {deadlocksCount}");
            }
        }

        private static void WhatKittyDoesNext(char c, long currentPosition)
        {
            switch (c)
            {
                case '@':
                    soulsCount++;
                    field[currentPosition] = '-';
                    break;

                case '*':
                    foodCount++;
                    field[currentPosition] = '-';
                    break;

                case 'x':
                    if (currentPosition % 2 == 0)
                    {
                        if (soulsCount > 0)
                        {
                            soulsCount--;
                            field[currentPosition] = '@';
                        }
                        else
                        {
                            deadlocked = true;
                            Console.WriteLine($"You are deadlocked, you greedy kitty!");
                            Console.WriteLine($"Jumps before deadlock: {jumps}");
                        }
                    }
                    else
                    {
                        if (foodCount > 0)
                        {
                            foodCount--;
                            field[currentPosition] = '*';
                        }
                        else
                        {
                            deadlocked = true;
                            Console.WriteLine($"You are deadlocked, you greedy kitty!");
                            Console.WriteLine($"Jumps before deadlock: {jumps}");
                        }
                    }
                    deadlocksCount++;
                    break;
                default:
                    break;
            }
        }
    }
}