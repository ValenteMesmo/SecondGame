

namespace Common.GameComponents
{
    public class Ground
    {
        public Collider Collider { get; }

        public Ground(Sandbox sandbox, Dimension dimension)
        {
            Collider = new Collider(
                sandbox,
                dimension.X,
                dimension.Y,
                dimension.Width,
                dimension.Height,
                GetType());
                        
            sandbox.GroundCreated.Publish(Collider);
        }
    }
}
