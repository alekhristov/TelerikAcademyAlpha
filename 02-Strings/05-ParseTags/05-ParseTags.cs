using System;
using System.Text.RegularExpressions;

namespace _05_ParseTags
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            //var pattern = @"(<upcase>)(?<toUpper>.*?)(<\/upcase>)";
            //var matches = Regex.Matches(text, pattern, RegexOptions.Singleline);

            //foreach (Match match in matches)
            //{
            //    var toBeReplaced = match.Groups[0].Value;
            //    var toUpper = match.Groups["toUpper"].Value;
            //    text = text.Replace(toBeReplaced, toUpper.ToUpper());
            //}
            //Console.WriteLine(text);

            Console.WriteLine(Regex.Replace(text, "<upcase>(.*?)</upcase>", word => word.Groups[1].Value.ToUpper()));
        }
    }
}
