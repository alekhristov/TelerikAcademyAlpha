using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.Swappings
{
    class Node
    {
        public Node(int value, Node prev)
        {
            this.Value = value;
            this.Previous = prev;

            if (prev != null)
            {
                this.Previous.Next = this;
            }
        }

        public int Value { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = input[0];
            var k = input[1];
            var numbersToShuffle = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var dict = new Dictionary<int, Node>();

            Node head = null;
            Node tail = null;
            Node prev = null;

            for (int i = 1; i <= n; i++)
            {
                var node = new Node(i, prev);
                prev = node;

                if (head == null)
                {
                    head = node;
                }

                tail = node;
                dict.Add(i, node);
            }

            for (int i = 0; i < k; i++)
            {
                var numberToAddNode = dict[numbersToShuffle[i]];
                var numberToAdd = numberToAddNode.Value;

                if (numberToAdd % 2 == 0)
                {
                    numberToAdd /= 2;
                }
                else
                {
                    numberToAdd *= 2;

                    if (numberToAdd > dict[dict.Count].Value)
                    {
                        numberToAdd = dict[dict.Count].Value;
                    }
                }

                var numbertoAddAfterNode = dict[numberToAdd];

                if (numberToAddNode.Value != numbertoAddAfterNode.Value)
                {
                    Add(numberToAddNode, numbertoAddAfterNode, ref head);
                }
            }

            var current = head;

            var sb = new StringBuilder();

            while (current != null)
            {
                sb.Append($"{current.Value} ");
                current = current.Next;
            }

            sb.Length--;
            Console.WriteLine(sb);
        }

        public static void Add(Node numberToAdd, Node numberToAddAfter, ref Node head)
        {
            var previous = numberToAdd.Previous;
            var next = numberToAdd.Next;

            if (previous == null)
            {
                next.Previous = null;
                head = next;
            }
            else
            {
                if (next != null)
                {
                    next.Previous = previous;
                }
            }
            if (next == null)
            {
                previous.Next = null;
            }
            else
            {
                if (previous != null)
                {
                    previous.Next = next;
                }
            }

            if (numberToAddAfter.Next == null)
            {
                numberToAdd.Next = null;
            }
            else
            {
                numberToAdd.Next = numberToAddAfter.Next;
            }
            numberToAdd.Previous = numberToAddAfter;
            numberToAddAfter.Next = numberToAdd;

            if (numberToAdd.Next != null)
            {
                numberToAdd.Next.Previous = numberToAdd;
            }
        }
    }
}
