using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CrookedStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBrickHeight = long.Parse(Console.ReadLine());
            var secondBrickHeight = long.Parse(Console.ReadLine());
            var thirdBrickHeight = long.Parse(Console.ReadLine());
            var numberOfLayers = int.Parse(Console.ReadLine());
            int numberOfBricks = 0;
            var listOfBricks = new List<long>();
            listOfBricks.Add(firstBrickHeight);
            listOfBricks.Add(secondBrickHeight);
            listOfBricks.Add(thirdBrickHeight);


            for (int i = numberOfLayers; i > 0; i--)
            {
                numberOfBricks += i;
            }

            long nextBrickHeight = 0;

            for (int i = 3; i < numberOfBricks; i++)
            {
                nextBrickHeight = firstBrickHeight + secondBrickHeight + thirdBrickHeight;
                listOfBricks.Add(nextBrickHeight);
                firstBrickHeight = secondBrickHeight;
                secondBrickHeight = thirdBrickHeight;
                thirdBrickHeight = nextBrickHeight;
            }

            int counter = 0;

            for (int i = 1; i <= numberOfLayers; i++)
            {
                string currentLine = string.Empty;
                for (int k = 0; k < i; k++)
                {
                    currentLine += listOfBricks[counter] + " ";
                    counter++;
                }
                currentLine = currentLine.TrimEnd();
                Console.WriteLine(currentLine);
            }
        }
    }
}
