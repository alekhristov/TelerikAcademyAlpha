using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07_ExtractSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var input = Console.ReadLine().Split('.');
            var result = new List<string>();
            var pattern = @"\b" + word + @"\b";

            foreach (var sentence in input)
            {
                var matchedSentence = Regex.Match(sentence, pattern);
                if (matchedSentence.Success)
                {
                    result.Add(sentence.Trim());
                }
            }
            if (result.Count > 1)
            {
                Console.WriteLine(string.Join(". ", result) + ".");
            }
            else if(result.Count == 1)
            {
                Console.WriteLine(result[0] + '.');
            }
        }
    }
}
