namespace Common
{
    public class Dimension : Position
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Dimension(float x, float y, int width, int height) : base(x, y)
        {
            Width = width;
            Height = height;
        }
    }
}
