

namespace Common.GameComponents
{
    public class Ground
    {
        public Collider Collider { get; }

        public Ground(Sandbox sandbox, Position position)
        {
            Collider = new Collider(
                sandbox,
                position.X,
                position.Y,
                3,
                3,
                GetType());
                        
            sandbox.GroundCreated.Publish(Collider);
        }
    }
}
