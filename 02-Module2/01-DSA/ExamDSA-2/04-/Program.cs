using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var males = new Dictionary<string, List<string>>();
            var females = new Dictionary<string, List<string>>();
            var dict = new SortedDictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var gender = char.Parse(Console.ReadLine());
                var numberOfInterest = int.Parse(Console.ReadLine());
                var interests = Console.ReadLine().Split(',').ToList();

                if (gender == 'm')
                {
                    if (!males.ContainsKey(name))
                    {
                        males[name] = new List<string>();
                    }
                    males[name] = interests;
                }
                else
                {
                    if (!females.ContainsKey(name))
                    {
                        females[name] = new List<string>();
                    }
                    females[name] = interests;
                }
            }

            foreach (var male in males.Where(kvp => kvp.Value.Count > 0))
            {
                foreach (var interest in male.Value)
                {
                    foreach (var female in females)
                    {
                        var femName = female.Key;

                        foreach (var interest2 in female.Value)
                        {
                            if (male.Value.Contains(interest2))
                            {
                                if (interest == interest2)
                                {
                                    if (!dict.ContainsKey($"{male.Key} and {female.Key}"))
                                    {
                                        dict[$"{male.Key} and {female.Key}"] = 0;
                                    }
                                    dict[$"{male.Key} and {female.Key}"]++;
                                }
                            }
                        }
                    }
                }
            }

            var result = dict.OrderByDescending(kvp => kvp.Value).FirstOrDefault();

            Console.WriteLine($"{result.Key} have {result.Value} common interests!");
        }
    }
}