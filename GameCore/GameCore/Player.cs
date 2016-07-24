using GameCore.Commons;

namespace GameCore
{
    public class Player : IPlayer
    {
        private readonly Collider Collider;
        private readonly IUpdate PlayerUpdates;

        public Player(IUpdate playerUpdates, Collider collider)
        {
            Collider = collider;
            PlayerUpdates = playerUpdates;
        }

        public void Update(float deltaTime)
        {
            PlayerUpdates.Update(deltaTime);
        }

        public float GetX()
        {
            return Collider.X;
        }
    }
}