using System;

namespace _03_ReverseLinkedList
{
    class ReverseLinkedList
    {
        static void Main(string[] args)
        {
            var first = new Node<int>(1);
            var second = new Node<int>(2);
            var third = new Node<int>(3);
            var fourth = new Node<int>(4);
            first.Next = second;
            second.Next = third;
            third.Next = fourth;

            var current = first;
            Node<int> prev = null;
            Node<int> next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            first = prev;
            current = first;

            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}