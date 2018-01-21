//STRINGS SOLUTION
using System;
using System.Linq;
using System.Text;

namespace Slogan
{
    class Program
    {
        static int n;
        static string[] words;
        static string slogan;
        static StringBuilder resultSb = new StringBuilder();
        static StringBuilder tempSb = new StringBuilder();
        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                words = Console.ReadLine().Split();
                slogan = Console.ReadLine();
                string currentResult = slogan;

                foreach (string word in words)
                {
                    int timesMet = 0;
                    if (currentResult.StartsWith(word))
                    {
                        timesMet++;
                    }
                    if (currentResult.EndsWith(word) && currentResult.Length > word.Length)
                    {
                        timesMet++;
                    }
                    string[] splitResult = currentResult.Split(new string[] { word }, StringSplitOptions.RemoveEmptyEntries);
                    if (splitResult.Length > 1)
                    {
                        timesMet += splitResult.Length - 1;
                    }
                    currentResult = string.Join("", splitResult);
                    if (timesMet > 0)
                    {
                        tempSb.Append(String.Join(" ", Enumerable.Repeat(word, timesMet)));
                        tempSb.Append(' ');
                    }
                }
                if (currentResult.Length > 0)
                {
                    resultSb.AppendLine("NOT VALID");
                }
                else
                {
                    while (slogan != string.Empty)
                    {
                        foreach (var word in words)
                        {
                            if (slogan.StartsWith(word))
                            {
                                resultSb.Append($"{word} ");
                                slogan = slogan.Substring(word.Length);

                                if (slogan == string.Empty)
                                {
                                    resultSb.AppendLine();
                                    break;
                                }
                            }
                        }
                    }
                }
                tempSb.Clear();
            }
            Console.WriteLine(resultSb.ToString().TrimEnd());
        }
    }
}
//RECURSIVE SOLUTION
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Slogan
//{
//    class Program
//    {
//        static HashSet<string> wordsAllowed;
//        static string sloganSuggested;
//        static StringBuilder result = new StringBuilder();
//        static Stack<string> matchedWords;

//        static void Main(string[] args)
//        {
//            var n = int.Parse(Console.ReadLine());

//            for (int i = 0; i < n; i++)
//            {
//                wordsAllowed = new HashSet<string>(Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
//                sloganSuggested = Console.ReadLine();

//                matchedWords = new Stack<string>();

//                if (FindSlogans(sloganSuggested))
//                {
//                    result.AppendLine(string.Join(" ", matchedWords));
//                }
//                else
//                {
//                    result.AppendLine("NOT VALID");
//                }

//            }
//            Console.Write(result);
//        }

//        private static bool FindSlogans(string slogan)
//        {
//            if (slogan.Length == 0)
//            {
//                return true;
//            }

//            foreach (var word in wordsAllowed)
//            {
//                if (slogan.StartsWith(word))
//                {
//                    var currentSlogan = slogan.Substring(word.Length);

//                    if (FindSlogans(currentSlogan))
//                    {
//                        matchedWords.Push(word);
//                        return true;
//                    }
//                }
//            }
//            return false;
//        }
//    }
//}