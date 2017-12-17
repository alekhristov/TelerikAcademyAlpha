using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01_SecretNumeralSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            var dict = new Dictionary<string, int>();
            var result = new List<string>();

            dict.Add("hristofor", 3);
            dict.Add("hristo", 0);
            dict.Add("tosho", 1);
            dict.Add("pesho", 2);
            dict.Add("vladimir", 7);
            dict.Add("vlad", 4);
            dict.Add("haralampi", 5);
            dict.Add("zoro", 6);

            var nameName = string.Empty;
            var addedToResult = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                var currentN = input[i].ToCharArray();

                for (int j = 0; j < currentN.Length; j++)
                {
                    nameName += currentN[j];

                    foreach (var item in dict)
                    {
                        if (nameName == item.Key)
                        {
                            if (nameName == "vlad" && currentN.Length > 4 && j + 1 < currentN.Length - 1 && currentN[j+1] == 'i')
                            {
                                addedToResult += dict["vladimir"];
                                nameName = string.Empty;
                                j += 4;
                            }
                            else if (nameName == "vlad")
                            {
                                addedToResult += item.Value;
                                nameName = string.Empty;
                            }

                            else if (nameName == "hristo" && currentN.Length > 6 && j + 1 < currentN.Length - 1 && currentN[j + 1] == 'f')
                            {
                                addedToResult += dict["hristofor"];
                                nameName = string.Empty;
                                j += 3;
                            }
                            else if (nameName == "hristo")
                            {
                                addedToResult += item.Value;
                                nameName = string.Empty;
                            }
                            else
                            {
                                addedToResult += item.Value;
                                nameName = string.Empty;
                            }
                        }
                    }
                }
                result.Add(addedToResult);
                addedToResult = string.Empty;
            }

            BigInteger product = 1;
            foreach (var item in result)
            {
                long number = Convert.ToInt64(item, 8);
                product *= long.Parse(number.ToString());
            }

            Console.WriteLine(product);
        }
    }
}
