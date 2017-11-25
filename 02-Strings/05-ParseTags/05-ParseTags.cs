using System;
using System.Text.RegularExpressions;

namespace _05_ParseTags
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = @"(<upcase>)(?<toUpper>.*?)(<\/upcase>)";
            var matches = Regex.Matches(text, pattern, RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                var toBeReplaced = match.Groups[0].Value;
                var toUpper = match.Groups["toUpper"].Value;
                text = text.Replace(toBeReplaced, toUpper.ToUpper());
            }
            Console.WriteLine(text);

            //var input = Console.ReadLine();
            //var strToUpper = string.Empty;
            //var startIndex = 0;

            //for (int i = 0; i < input.Length - 1; i++)
            //{
            //    if (input[i] == '<' && input[i + 1] != '/')
            //    {
            //        input = input.Remove(i, 8);
            //        strToUpper += input[i + 1];
            //        startIndex = i;
            //    }
            //    if (strToUpper != string.Empty)
            //    {
            //        if (input[i + 1] == '<')
            //        {
            //            input = input.Remove(i + 1, 9);
            //            input = input.Replace(input.Substring(startIndex, strToUpper.Length), input.Substring(startIndex, strToUpper.Length).ToUpper());
            //            strToUpper = string.Empty;
            //        }
            //        else
            //        {
            //            strToUpper += input[i + 1];
            //        }
            //    }
            //}
            //Console.WriteLine(input);
        }
    }
}
