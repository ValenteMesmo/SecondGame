
namespace Common.GameComponents.Factories
{
    class GroundFactory
    {
        private readonly Sandbox Sandbox;
        public GroundFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.GroundAdded.Subscribe(CreateGround);
        }

        private void CreateGround(Position dimension)
        {
            new Ground(Sandbox, dimension);
        }
    }
}
