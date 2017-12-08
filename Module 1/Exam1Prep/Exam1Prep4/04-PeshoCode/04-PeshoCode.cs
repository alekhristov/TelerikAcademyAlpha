using System;

namespace _04_PeshoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());
            var text = string.Empty;
            var sum = 0;
            var startFromBeginning = false;

            for (int i = 0; i < n; i++)
            {
                text += Console.ReadLine() + " ";
            }

            var wordIndex = text.IndexOf(word);
            var endIndex = 0;
            var startIndex = 0;

            for (int i = wordIndex + word.Length; i < text.Length; i++)
            {
                if (text[i] == '.')
                {
                    startFromBeginning = true;
                    break;
                }
                else if (text[i] == '?')
                {
                    endIndex = i;
                    break;
                }
            }

            if (startFromBeginning)
            {
                for (int i = wordIndex; i >= 0; i--)
                {
                    if (char.IsUpper(text[i]))
                    {
                        startIndex = i;
                        break;
                    }
                }

                text = text.Substring(startIndex, wordIndex - 1 - startIndex).ToUpper();
            }
            else
            {
                text = text.Substring(wordIndex + word.Length, endIndex - (wordIndex + word.Length)).ToUpper();
                }

            foreach (var item in text)
            {
                if (!char.IsWhiteSpace(item))
                {
                    sum += item;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
