namespace _14.Labyrinth
{
    internal class MatrixItem
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Value { get; set; }

        public MatrixItem(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public MatrixItem(MatrixItem m)
        {
            this.X = m.X;
            this.Y = m.Y;
            this.Value = m.Value;
        }
    }
}