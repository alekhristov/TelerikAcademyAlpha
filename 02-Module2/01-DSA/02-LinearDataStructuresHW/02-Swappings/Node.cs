namespace _02_Swappings
{
    class Node
    {
        public Node()
        {

        }
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public Node Next { get; set; }

        //public Node<T> Previous { get; set; }
    }
}
