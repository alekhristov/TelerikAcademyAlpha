using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_HarryPotter
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensionSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var coordinatesHP = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfBasiliks = int.Parse(Console.ReadLine());
            var dict = new Dictionary<char, string>();
            var counter = 0;
            var update = string.Empty;

            for (int i = 0; i < numberOfBasiliks; i++)
            {
                var basilisk = Console.ReadLine();
                var basiliskName = basilisk[0];

                dict.Add(basiliskName, basilisk.Substring(2));
            }

            var command = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "END")
            {
                var unitName = Convert.ToChar(command[0]);
                var dimension = Convert.ToChar(command[1]);
                var value = int.Parse(command[2]);

                if (char.IsLetter(unitName))
                {
                    foreach (var item in dict)
                    {
                        if (item.Key == unitName)
                        {
                            var basiliksPosition = item.Value.Split().Select(int.Parse).ToArray();
                            switch (dimension)
                            {
                                case 'A':
                                    basiliksPosition[0] += value;
                                    if (basiliksPosition[0] < 0)
                                    {
                                        basiliksPosition[0] = 0;
                                    }
                                    else if (basiliksPosition[0] > dimensionSize[0] - 1)
                                    {
                                        basiliksPosition[0] = dimensionSize[0] - 1;
                                    }
                                    break;
                                case 'B':
                                    basiliksPosition[1] += value;
                                    if (basiliksPosition[1] < 0)
                                    {
                                        basiliksPosition[1] = 0;
                                    }
                                    else if (basiliksPosition[1] > dimensionSize[1] - 1)
                                    {
                                        basiliksPosition[1] = dimensionSize[1] - 1;
                                    }
                                    break;
                                case 'C':
                                    basiliksPosition[2] += value;
                                    if (basiliksPosition[2] < 0)
                                    {
                                        basiliksPosition[2] = 0;
                                    }
                                    else if (basiliksPosition[2] > dimensionSize[2] - 1)
                                    {
                                        basiliksPosition[2] = dimensionSize[2] - 1;
                                    }
                                    break;
                                case 'D':
                                    basiliksPosition[3] += value;
                                    if (basiliksPosition[3] < 0)
                                    {
                                        basiliksPosition[3] = 0;
                                    }
                                    else if (basiliksPosition[3] > dimensionSize[3] - 1)
                                    {
                                        basiliksPosition[3] = dimensionSize[3] - 1;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            update = basiliksPosition[0] + " " + basiliksPosition[1] + " " + basiliksPosition[2] + " " + basiliksPosition[3];
                            if (basiliksPosition[0] == coordinatesHP[0] && basiliksPosition[1] == coordinatesHP[1] &&
                                basiliksPosition[2] == coordinatesHP[2] && basiliksPosition[3] == coordinatesHP[3])
                            {
                                Console.WriteLine(@"{0}: ""You thought you could escape, didn't you?"" - {1}", item.Key, counter);
                                return;
                            }
                        }
                    }
                    dict[unitName] = update;
                }
                else if (unitName == '@')
                {
                    counter++;
                    switch (dimension)
                    {
                        case 'A':
                            coordinatesHP[0] += value;
                            if (coordinatesHP[0] < 0)
                            {
                                coordinatesHP[0] = 0;
                            }
                            else if (coordinatesHP[0] > dimensionSize[0] - 1)
                            {
                                coordinatesHP[0] = dimensionSize[0] - 1;
                            }
                            break;
                        case 'B':
                            coordinatesHP[1] += value;
                            if (coordinatesHP[1] < 0)
                            {
                                coordinatesHP[1] = 0;
                            }
                            else if (coordinatesHP[1] > dimensionSize[1] - 1)
                            {
                                coordinatesHP[1] = dimensionSize[1] - 1;
                            }
                            break;
                        case 'C':
                            coordinatesHP[2] += value;
                            if (coordinatesHP[2] < 0)
                            {
                                coordinatesHP[2] = 0;
                            }
                            else if (coordinatesHP[2] > dimensionSize[2] - 1)
                            {
                                coordinatesHP[2] = dimensionSize[2] - 1;
                            }
                            break;
                        case 'D':
                            coordinatesHP[3] += value;
                            if (coordinatesHP[3] < 0)
                            {
                                coordinatesHP[3] = 0;
                            }
                            else if (coordinatesHP[3] > dimensionSize[3] - 1)
                            {
                                coordinatesHP[3] = dimensionSize[3] - 1;
                            }
                            break;
                        default:
                            break;
                    }
                    foreach (var item in dict.OrderBy(kvp => kvp.Key))
                    {
                        var basiliksPosition = item.Value.Split().Select(int.Parse).ToArray();

                        if (basiliksPosition[0] == coordinatesHP[0] && basiliksPosition[1] == coordinatesHP[1] &&
                                    basiliksPosition[2] == coordinatesHP[2] && basiliksPosition[3] == coordinatesHP[3])
                        {
                            Console.WriteLine(@"{0}: ""Step {1} was the worst you ever made.""", item.Key, counter);
                            Console.WriteLine(@"{0}: ""You will regret until the rest of your life... All 3 seconds of it!""", item.Key);
                            return;
                        }
                    }
                }
                command = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            Console.WriteLine(@"@: ""I am the chosen one!"" - {0}", counter);
        }
    }
}
