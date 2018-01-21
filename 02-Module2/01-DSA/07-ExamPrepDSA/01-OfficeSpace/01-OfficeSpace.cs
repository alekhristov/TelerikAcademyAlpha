using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_OfficeSpace
{
    class Node
    {
        public int ChildsCount { get; set; }

        public List<int> Parents { get; set; }

        public bool IsVisited { get; set; }
    }

    class Program
    {
        static int taskDependency;
        static int result;
        static SortedDictionary<int, Node> graph = new SortedDictionary<int, Node>();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var tasksTime = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool isDependent = false;

            for (int i = 0; i < n; i++)
            {
                var tasksDependencies = Console.ReadLine().Split().Select(int.Parse).ToArray();
                isDependent = false;

                for (int j = 0; j < tasksDependencies.Length; j++)
                {
                    taskDependency = tasksDependencies[j];

                    if (taskDependency == 0)
                    {
                        continue;
                    }
                    isDependent = true;

                    var child = tasksTime[i];
                    var parent = tasksTime[taskDependency - 1];

                    if (!graph.ContainsKey(parent))
                    {
                        graph.Add(parent, new Node());
                    }
                    if (!graph.ContainsKey(child))
                    {
                        graph.Add(child, new Node());
                    }

                    if (graph[child].Parents == null)
                    {
                        graph[child].Parents = new List<int>();
                    }

                    graph[child].Parents.Add(parent);
                    graph[parent].ChildsCount++;
                }
            }

            if (!isDependent)
            {
                result = tasksTime.Max();
            }
            else
            {
                if (TopologicalSort(tasksTime))
                {
                    result = -1;
                }
            }
            Console.WriteLine(result);
        }

        private static bool TopologicalSort(int[] tasksTime)
        {
            bool hasCircularDependency = true;

            foreach (var task in graph)
            {
                if (task.Value.ChildsCount == 0 && task.Value.Parents != null)
                {
                    hasCircularDependency = false;
                    result += task.Key;
                    var node = task.Value;

                    while (node.Parents != null)
                    {
                        var largestParent = node.Parents.Max();
                        result += largestParent;
                        node = graph[largestParent];
                    }
                    break;
                }
            }
            return hasCircularDependency;
        }
    }
}
