using System;

namespace _02_Swappings
{
    class LinkedList
    {
        private Node head;
        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public void AddFirst(int value)
        {
            Node toAdd = new Node();

            toAdd.Value = value;
            toAdd.Next = head;

            head = toAdd;
        }

        public void AddLast(int value)
        {
            if (head == null)
            {
                head = new Node();

                head.Value = value;
                head.Next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.Value = value;

                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toAdd;
            }
        }
    }
}
