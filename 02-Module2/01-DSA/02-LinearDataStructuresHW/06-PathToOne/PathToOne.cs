using System;

namespace _06_PathToOne
{
    class PathToOne
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var count = 0;

            while (true)
            {
                var countAdd = 0;
                var countSubtract = 0;

                while (num % 2 == 0)
                {
                    count++;
                    num /= 2;

                    if (num == 1)
                    {
                        Console.WriteLine(count);
                        return;
                    }
                }
                var copyNum = num + 1;

                while (copyNum % 2 == 0)
                {
                    copyNum /= 2;
                    countAdd++;
                }
                copyNum = num - 1;

                while (copyNum % 2 == 0)
                {
                    copyNum /= 2;
                    countSubtract++;
                }

                if (countSubtract > countAdd || num == 3)
                {
                    num--;
                    count++;
                }
                else
                {
                    num++;
                    count++;
                }
            }
        }
    }
}
