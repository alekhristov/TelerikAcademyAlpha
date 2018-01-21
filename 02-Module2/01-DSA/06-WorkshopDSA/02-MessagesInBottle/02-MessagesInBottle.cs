using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_MessagesInBottle
{
    class MessagesInBottle
    {
        static HashSet<string> results = new HashSet<string>();
        static StringBuilder currentResult = new StringBuilder();
        static List<KeyValuePair<char, string>> decoding = new List<KeyValuePair<char, string>>();
        static string message;

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            var cipher = Console.ReadLine().ToCharArray();
            var key = '@';

            var strValue = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    key = cipher[i];
                }
                else
                {
                    strValue.Append(cipher[i]);
                    //Creates new KeyValuePair if we are in the last iteration or if the next element is a Letter
                    if (i == cipher.Length - 1 || (cipher[i + 1] >= 'A' && cipher[i] <= 'Z'))
                    {
                        decoding.Add(new KeyValuePair<char, string>(key, strValue.ToString()));
                        strValue.Clear();
                    }
                }
            }

            Recursion(0);

            Console.WriteLine(results.Count);

            foreach (var item in results.OrderBy(c => c))
            {
                Console.WriteLine(item);
            }
        }

        private static void Recursion(int messageIndex)
        {
            if (messageIndex == message.Length)
            {
                results.Add(currentResult.ToString());
                return;
            }

            foreach (var kvp in decoding)
            {
                var currentMessages = message.Substring(messageIndex);

                if (currentMessages.StartsWith(kvp.Value))
                {
                    currentResult.Append(kvp.Key);
                    Recursion(messageIndex + kvp.Value.Length);
                    currentResult.Length--;
                }
            }
        }
    }
}
