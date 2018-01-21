using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static Dictionary<string, Dictionary<string, SortedSet<string>>> dependencies = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
        private static HashSet<string> used;
        //static StringBuilder result = new StringBuilder();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                int firstSpaceIndex = line.IndexOf(" ");
                int secondSpaceIndex = line.IndexOf(" ", firstSpaceIndex + 1);
                string P1 = line.Substring(0, firstSpaceIndex);
                string P2 = line.Substring(firstSpaceIndex + 1, secondSpaceIndex - (firstSpaceIndex + 1));
                string subject = line.Substring(secondSpaceIndex + 1);

                if (!dependencies.ContainsKey(P1))
                {
                    dependencies[P1] = new Dictionary<string, SortedSet<string>>();
                }

                if (!dependencies[P1].ContainsKey(subject))
                {
                    dependencies[P1][subject] = new SortedSet<string>();
                }

                dependencies[P1][subject].Add(P2);
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();
                int firstSpaceIndex = line.IndexOf(" ");
                string ofPerson = line.Substring(0, firstSpaceIndex);
                string inSubject = line.Substring(firstSpaceIndex + 1);
                used = new HashSet<string>();
                DFS(ofPerson, inSubject);
                //result.AppendFormat("{0}{1}", ofPerson, Environment.NewLine);
                Console.Write("{0}{1}", ofPerson, Environment.NewLine);
            }

            //Console.Write(result);
        }

        private static void DFS(string currentPerson, string inSubject)
        {
            used.Add(currentPerson);

            if (!(dependencies.ContainsKey(currentPerson) && dependencies[currentPerson].ContainsKey(inSubject)))
            {
                return;
            }

            foreach (var dependency in dependencies[currentPerson][inSubject])
            {
                if (!used.Contains(dependency))
                {
                    DFS(dependency, inSubject);
                    //result.AppendFormat("{0}, ", dependency);
                    Console.Write("{0}, ", dependency);
                }
            }
        }
    }
}