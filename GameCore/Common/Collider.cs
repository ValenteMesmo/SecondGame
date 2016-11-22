using Common.PubSubEngine;
using System;

namespace Common
{
    public class Collider
    {
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool Trigger { get; }
        public Type Parent { get; }

        public Collider(
            Sandbox sandbox, 
            float x, 
            float y, 
            int width, 
            int height, 
            Type parentType,
            bool trigger = false)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Name =
#if DEBUG
                parentType.Name + 
#endif
                Guid.NewGuid().ToString();
            Trigger = trigger;
            Parent = parentType;
            sandbox.ColliderCreated.Publish(this);
        }
    }
}