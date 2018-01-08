namespace DeleteANodeInLinkedList
{
    class Node<T>
    {
        public Node()
        {

        }

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}
