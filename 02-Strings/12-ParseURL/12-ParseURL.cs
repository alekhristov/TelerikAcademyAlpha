using System;
using System.Text.RegularExpressions;

namespace _12_ParseURL
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"^(?<protocol>.*)://(?<server>.*?)(?<resource>/.*)$";

            var matchedUrl = Regex.Match(input, pattern, RegexOptions.Multiline);
            if (matchedUrl.Success)
            {
                Console.WriteLine("[protocol] = {0}", matchedUrl.Groups["protocol"].Value);
                Console.WriteLine("[server] = {0}", matchedUrl.Groups["server"].Value);
                Console.WriteLine("[resource] = {0}", matchedUrl.Groups["resource"].Value);
            }

            //Solution using String class only
            //var url = Console.ReadLine();
            //var protocol = url.Substring(0, url.IndexOf(':'));

            //url = url.Remove(0, url.IndexOf(':') + 3);
            //var server = url.Substring(0, url.IndexOf('/'));

            //url = url.Remove(0, url.IndexOf('/'));
            //var resource = url;

            //Console.WriteLine("[protocol] = {0}", protocol);
            //Console.WriteLine("[server] = {0}", server);
            //Console.WriteLine("[resource] = {0}", resource);
        }
    }
}
