using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SoupScript
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = string.Empty;
            var sb = new StringBuilder();
            var newBlock = false;

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();
                inputLine = inputLine.Trim();
                var commentIndex = inputLine.IndexOf(@"//");
                var comment = inputLine.Substring(commentIndex);
                var line = string.Empty;

                if (commentIndex >= 0)
                {
                    sb.AppendLine(comment);
                }
                for (int k = 0; k < inputLine.Length; k++)
                {
                    if (!char.IsWhiteSpace(inputLine[k]))
                    {
                        if (newBlock)
                        {
                            line += "    ";
                        }
                        if (inputLine[k] == '}')
                        {
                            line += '}';
                            newBlock = false;
                        }
                        if (inputLine[k] == '.')
                        {
                            line = line.TrimEnd();
                            line += '.';
                        }
                        else if (inputLine[k] == '(')
                        {
                            inputLine += '(';
                            if (inputLine[k + 1] == ' ')
                            {
                                continue;
                            }
                        }
                        else if (inputLine[k] == '=' || inputLine[k] == '-' || inputLine[k] == '+' || inputLine[k] == '>' || inputLine[k] == '<')
                        {
                            line = line.TrimEnd();
                            line += " =";
                            if (inputLine[k+1] != ' ')
                            {
                                line += ' ';
                            }
                        }
                        else if (inputLine[k] == ';')
                        {
                            line = line.TrimEnd();
                            line += ';';
                        }
                        else if (inputLine[k] == '{')
                        {
                            line = line.TrimEnd();
                            line += " {";
                            newBlock = true;
                        }
                        else
                        {
                            line += inputLine[k];
                        }
                    }
                    else
                    {
                        if (line[line.Length - 1] != ' ')
                        {
                            line += ' ';
                        }
                    }
                }
            }
        }
    }
}
