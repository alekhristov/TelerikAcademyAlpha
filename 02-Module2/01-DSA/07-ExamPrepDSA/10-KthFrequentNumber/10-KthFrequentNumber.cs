using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _10_KthFrequentNumber
{
    class Kvp : IComparable<Kvp>
    {
        public Kvp(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int Key { get; set; }

        public int Value { get; set; }

        public int CompareTo(Kvp other)
        {
            if (this.Value == other.Value)
            {
                return this.Key.CompareTo(other.Key);
            }
            return -this.Value.CompareTo(other.Value);
        }
    }
    class Program
    {
        static OrderedSet<Kvp> bag = new OrderedSet<Kvp>();
        static Dictionary<int, Kvp> dict = new Dictionary<int, Kvp>();
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                switch (command)
                {
                    case "ADD":
                        Add(int.Parse(input[1]));
                        break;
                    case "GET":
                        Get(int.Parse(input[1]));
                        break;
                    case "REMOVE":
                        Remove(int.Parse(input[1]));
                        break;
                    case "END":
                        Console.Write(result);
                        return;
                }
            }
        }

        private static void Remove(int num)
        {
            if (dict.ContainsKey(num))
            {
                result.AppendLine(string.Format("Ok: Number {0} removed", num));

            }
            else
            {
                result.AppendLine(string.Format("Error: Number {0} not found", num));
            }
        }

        private static void Get(int position)
        {
            if (position < 1 || position > dict.Count)
            {
                result.AppendLine(string.Format("Error: {0} is invalid K", position));
            }

            else
            {
                var counter = 1;
                foreach (var kvp in dict.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
                {
                    if (counter == position)
                    {
                        result.AppendLine(string.Format("Ok: Found {0}", kvp.Key));
                        break;
                    }
                    counter++;
                }
            }
        }

        private static void Add(int num)
        {
            if (!dict.ContainsKey(num))
            {
                dict[num] = new Kvp(num, 0);
                bag.Add(new Kvp(num, 0));
            }

            bag.Where(x => x.Equals(dict[num])).FirstOrDefault().Value++;
            dict[num].Value++;
            result.AppendLine(string.Format("Ok: {0} added", num));
        }
    }
}
