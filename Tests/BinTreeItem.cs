namespace Tests
{
    public class BinTreeItem
    {
        public BinTreeItem(int i, int j, int value)
        {
            this.X = i;
            this.Y = j;
            this.Value = value;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }
}