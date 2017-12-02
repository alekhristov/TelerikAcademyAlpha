using System;
using System.Linq;

namespace _01_Kitty
{
    class Program
    {
        static int soulsCount = 0;
        static int foodCount = 0;
        static int deadlocksCount = 0;
        static int currentPosition = 0;
        static bool deadlocked = false;
        static int jumps = 0;
        static char[] input = Console.ReadLine().ToArray();

        static void Main(string[] args)
        {
            var kittyPath = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            CheckWhatTheKittyDoes(input[currentPosition]);

            for (int i = 0; i < kittyPath.Length; i++)
            {
                var currentMove = kittyPath[i];
                currentPosition = (currentPosition + currentMove) % input.Length;

                if (currentPosition > input.Length - 1)
                {
                    currentPosition -= input.Length;
                }
                else if (currentPosition < 0)
                {
                    currentPosition += input.Length;
                }

                CheckWhatTheKittyDoes(input[currentPosition]);

                if (deadlocked == true)
                {
                    Console.WriteLine("You are deadlocked, you greedy kitty!");
                    Console.WriteLine($"Jumps before deadlock: {jumps}");
                    return;
                }
                jumps++;
            }

            Console.WriteLine($"Coder souls collected: {soulsCount}");
            Console.WriteLine($"Food collected: {foodCount}");
            Console.WriteLine($"Deadlocks: {deadlocksCount}");

        }

        private static void CheckWhatTheKittyDoes(char currentElement)
        {
            switch (currentElement)
            {
                case '@':
                    soulsCount++;
                    input[currentPosition] = '-';
                    break;

                case '*':
                    foodCount++;
                    input[currentPosition] = '-';
                    break;

                case 'x':
                    deadlocksCount++;
                    if (currentPosition % 2 == 0)
                    {
                        if (soulsCount > 0)
                        {
                            soulsCount--;
                            input[currentPosition] = '@';
                        }
                        else
                        {
                            deadlocked = true;
                        }
                    }
                    else
                    {
                        if (foodCount > 0)
                        {
                            foodCount--;
                            input[currentPosition] = '*';
                        }
                        else
                        {
                            deadlocked = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}