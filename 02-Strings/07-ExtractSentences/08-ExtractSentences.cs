using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _07_ExtractSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            StringBuilder builder = new StringBuilder();
            List<string> sentences = text.Split('.').ToList();

            List<char> separators = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsLetter(text[i]) && !separators.Contains(text[i]))
                {
                    separators.Add(text[i]);
                }
            }
            char[] separatorsArray = separators.ToArray();

            foreach (string sentence in sentences)
            {
                List<string> words = sentence.Split(separatorsArray, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (words.Contains(word))
                {
                    builder.Append(sentence.Trim() + ". ");
                }
            }
            Console.WriteLine(builder.ToString().Trim());

            //var word = Console.ReadLine();
            //var input = Console.ReadLine().Split('.');
            //var result = new List<string>();
            //var pattern = @"\b" + word + @"\b";

            //foreach (var sentence in input)
            //{
            //    var matchedSentence = Regex.Match(sentence, pattern);
            //    if (matchedSentence.Success)
            //    {
            //        result.Add(sentence.Trim());
            //    }
            //}
            //if (result.Count > 1)
            //{
            //    Console.WriteLine(string.Join(". ", result) + ".");
            //}
            //else if(result.Count == 1)
            //{
            //    Console.WriteLine(result[0] + '.');
            //}
        }
    }
}
