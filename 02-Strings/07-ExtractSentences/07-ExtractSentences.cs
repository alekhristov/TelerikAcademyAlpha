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
            var input = Console.ReadLine();
            var asd = Regex.Split(input, @"(?<sentence>\w*\W*?.*?\.)");
            var pattern = @"\b" + word + @"\b";


            for (int i = 0; i < asd.Length; i++)
            {
                if (asd[i].Contains(word))
                {
                    int index = asd[i].IndexOf(word);
                    if (((char.Parse(asd[index - 1]) < 65 && char.Parse(asd[index - 1]) > 122) || asd[index - 1] == null) &&
                        (((char.Parse(asd[index + word.Length]) < 65 && char.Parse(asd[index + word.Length]) > 122)) || asd[index + word.Length] == null))
                    {
                        Console.Write(asd[i].Trim() + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
