using System;

namespace _04_GoshoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine().Trim();
            var n = int.Parse(Console.ReadLine());
            var text = string.Empty;
            var goForward = false;
            var result = string.Empty;
            var sum = 0;

            for (int i = 0; i < n; i++)
            {
                text += Console.ReadLine();
            }
            var index = text.IndexOf(word);
            var endIndex = 0;

            for (int i = index + word.Length; i < text.Length; i++)
            {
                if (text[i] == '.' || text[i] == '!')
                {
                    if (text[i] == '!')
                    {
                        endIndex = i + 1;
                        break;
                    }
                    else
                    {
                        goForward = true;
                        endIndex = i;
                        break;
                    }
                }
            }

            if (goForward)
            {
                result = text.Substring(index + word.Length, endIndex - (index + word.Length));
            }
            else
            {
                for (int i = index; i >= 0; i--)
                {
                    if (char.IsUpper(text[i]))
                    {
                        endIndex = i;
                        break;
                    }
                }
                result = text.Substring(endIndex, index - endIndex);
            }

            foreach (var c in result)
            {
                if (!char.IsWhiteSpace(c))
                {
                    sum += c * word.Length;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
