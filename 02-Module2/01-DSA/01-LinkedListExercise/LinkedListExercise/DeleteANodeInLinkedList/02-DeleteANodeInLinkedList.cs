using System;

namespace DeleteANodeInLinkedList
{
    class DeleteANodeInLinkedList
    {
        static void Main(string[] args)
        {
            //var first = new Node<int>(1);
            //first.Next = new Node<int>(2);
            //var second = first.Next;
            //second.Next = new Node<int>(3);
            //var third = second.Next;
            //third.Next = new Node<int>(4);
            //var fourth = third.Next;

            //var first = new Node<int>() { Value = 1 };
            //var second = new Node<int>() { Value = 2 };
            //var third = new Node<int>() { Value = 3 };
            //var fourth = new Node<int>() { Value = 4 };
            //first.Next = second;
            //second.Next = third;
            //third.Next = fourth;

            var first = new Node<int>(1);
            var second = new Node<int>(2);
            var third = new Node<int>(3);
            var fourth = new Node<int>(4);
            first.Next = second;
            second.Next = third;
            third.Next = fourth;

            var current = first;

            //Before deletion
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }

            second.Next = fourth;
            current = first;

            //After deletion
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }

            //.NET delete implementation
            //var linkedList = new LinkedList<int>();
            //var head = linkedList.AddFirst(1);
            //var tail = linkedList.AddLast(4);
            //var second = linkedList.AddAfter(head, 2);
            //var third = linkedList.AddBefore(tail, 3);

            ////Before deletion
            //foreach (var num in linkedList)
            //{
            //    Console.WriteLine(num);
            //}
            //Console.WriteLine("----");

            //linkedList.Remove(3);
            ////After deletion
            //foreach (var num in linkedList)
            //{
            //    Console.WriteLine(num);
            //}
        }
    }
}
