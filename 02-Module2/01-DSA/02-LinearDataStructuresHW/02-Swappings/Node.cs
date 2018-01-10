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
}
