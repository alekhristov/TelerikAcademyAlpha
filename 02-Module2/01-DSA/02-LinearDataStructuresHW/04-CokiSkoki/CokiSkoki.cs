using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_CokiSkoki
{
    class CokiSkoki
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var buildings = Console.ReadLine()
                .Split()
                .Select(short.Parse)
                .ToArray();

            var queueResult = new Queue<short>();
            var max = 0;
            var ultraMax = 0;

            for (int i = 0; i < n - 1; i++)
            {
                var currentBuilding = buildings[i];
                short count = 0;
                var index = i + 1;

                while (index <= buildings.Length - 1)
                {
                    var nextBuilding = buildings[index];
                    if (currentBuilding < nextBuilding)
                    {
                        count++;
                        currentBuilding = nextBuilding;
                    }
                    index++;
                }
                max = count;

                if (max > ultraMax)
                {
                    ultraMax = max;
                }
                queueResult.Enqueue(count);
            }
            queueResult.Enqueue(0);

            Console.WriteLine(ultraMax);
            Console.WriteLine(string.Join(" ", queueResult));
        }
    }
}
