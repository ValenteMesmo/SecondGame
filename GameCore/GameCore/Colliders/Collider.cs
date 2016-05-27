namespace GameCore
{
    public class Collider
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IUpdate Owner { get; set; }
    }
}