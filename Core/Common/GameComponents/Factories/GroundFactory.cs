
namespace Common.GameComponents.Factories
{
    class GroundFactory
    {
        private readonly Sandbox Sandbox;
        public GroundFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.AddGround.Subscribe(CreateGround);
        }

        private void CreateGround(Dimension dimension)
        {
            new Ground(Sandbox, dimension);
        }
    }
}
