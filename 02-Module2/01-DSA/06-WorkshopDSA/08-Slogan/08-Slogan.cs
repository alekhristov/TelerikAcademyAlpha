using System;
using System.Collections.Generic;
using System.Text;

namespace Slogan
{
    class Program
    {
        static HashSet<string> wordsAllowed;
        static string sloganSuggested;
        static StringBuilder result = new StringBuilder();
        static Stack<string> matchedWords;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                wordsAllowed = new HashSet<string>(Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                sloganSuggested = Console.ReadLine();

                matchedWords = new Stack<string>();

                if (FindSlogans(sloganSuggested))
                {
                    result.AppendLine(string.Join(" ", matchedWords));
                }
                else
                {
                    result.AppendLine("NOT VALID");
                }

            }
            Console.Write(result);
        }

        private static bool FindSlogans(string slogan)
        {
            if (slogan.Length == 0)
            {
                return true;
            }

            foreach (var word in wordsAllowed)
            {
                if (slogan.StartsWith(word))
                {
                    var currentSlogan = slogan.Substring(word.Length);

                    if (FindSlogans(currentSlogan))
                    {
                        matchedWords.Push(word);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}