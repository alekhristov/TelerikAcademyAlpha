using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_DogLovesPaper
{
    class Node
    {
        public int ParentsCount { get; set; }

        public HashSet<int> Childs { get; set; }

        public bool IsVisited { get; set; }
    }

    class Program
    {
        static SortedDictionary<int, Node> graph = new SortedDictionary<int, Node>();
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var direction = input[2];
                var parent = 0;
                var child = 0;

                if (direction == "before")
                {
                    parent = int.Parse(input[0]);
                    child = int.Parse(input[3]);
                }
                else if (direction == "after")
                {
                    parent = int.Parse(input[3]);
                    child = int.Parse(input[0]);
                }

                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, new Node());
                    graph[parent].Childs = new HashSet<int>();
                }
                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new Node());
                    graph[child].Childs = new HashSet<int>();
                }

                bool added = graph[parent].Childs.Add(child);

                if (added)
                {
                    graph[child].ParentsCount++;
                }
            }

            Console.WriteLine(TopologicalSort());
        }

        private static string TopologicalSort()
        {
            var areAllVisited = false;

            while (!areAllVisited)
            {
                areAllVisited = true;

                foreach (var kvp in graph)
                {
                    if (kvp.Key == 0 && result.Length == 0)
                    {
                        continue;
                    }
                    if (kvp.Value.ParentsCount == 0 && !kvp.Value.IsVisited)
                    {
                        result.Append(kvp.Key);
                        kvp.Value.IsVisited = true;

                        if (kvp.Value.Childs != null)
                        {
                            foreach (var num in kvp.Value.Childs)
                            {
                                if (graph.ContainsKey(num))
                                {
                                    graph[num].ParentsCount--;
                                }
                            }
                        }
                        areAllVisited = false;
                        break;
                    }
                }
            }
            return result.ToString();
        }
    }
}
