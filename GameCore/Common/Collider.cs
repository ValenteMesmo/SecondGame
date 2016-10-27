using System;

namespace Common
{
    public interface IGameObject
    {
        float X { get; }
        float Y { get; }
        float Width { get; }
        float Height { get; }
        string Name { get; }
    }

    public class Collider : IGameObject
    {
        public string Name { get; set; } 
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Collider(Sandbox sandbox, float x, float y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            sandbox.Pub(EventNames.COLLIDER_CREATED, this);
            Name = Guid.NewGuid().ToString();
        }
    }
}