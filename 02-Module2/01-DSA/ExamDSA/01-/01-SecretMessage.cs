using System;
using System.Collections.Generic;
using System.Text;

namespace _01_SecretMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stackBracketIndexes = new Stack<int>();
            var stackRepetitionNum = new Stack<int>();
            var currentSb = new StringBuilder();
            var inBrackets = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 48 && input[i] <= 57)
                {
                    currentSb.Append(input[i]);
                }
                else if (input[i] == '{')
                {
                    if (currentSb.Length > 0)
                    {
                        stackRepetitionNum.Push(int.Parse(currentSb.ToString()));
                        currentSb.Clear();
                    }
                    stackBracketIndexes.Push(i);
                }
                else if (input[i] == '}')
                {
                    var openBracketIndex = stackBracketIndexes.Pop();
                    var strInBrackets = input.Substring(openBracketIndex + 1, i - (openBracketIndex + 1));

                    var strRepetition = stackRepetitionNum.Pop();

                    for (int k = 0; k < strRepetition; k++)
                    {
                        inBrackets.Append(strInBrackets);
                    }
                    var toReplace = $"{strRepetition.ToString()}{{{strInBrackets}}}";
                    input = input.Replace(toReplace, inBrackets.ToString());
                    inBrackets.Clear();

                    if (input.Contains("{"))
                    {
                        var nextOpenBracketIndex = input.IndexOf('{');
                        var numIndex = nextOpenBracketIndex - 1;

                        while (numIndex >= 0 && input[numIndex] >= 48 && input[numIndex] <= 57)
                        {
                            numIndex--;
                        }
                        if (numIndex >= -1)
                        {
                            i = numIndex;
                        }
                        else
                        {
                            i = -1;
                        }
                    }
                }

            }
            Console.WriteLine(input);
        }
    }
}
