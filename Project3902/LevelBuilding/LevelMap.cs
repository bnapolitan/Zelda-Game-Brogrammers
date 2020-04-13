namespace Project3902.LevelBuilding
{
    class LevelMap
    {
        public string Top { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
        public string Bottom { get; set; }

        public LevelMap(string top, string left, string right, string bottom)
        {
            this.Top = top;
            this.Left = left;
            this.Right = right;
            this.Bottom = bottom;
        }
    }
}
