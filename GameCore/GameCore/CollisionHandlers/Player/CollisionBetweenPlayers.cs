using GameCore.Colliders;
using System;

namespace GameCore.CollisionHandlers
{
    public class CollisionBetweenPlayers : IHandleCollision
    {
        public void Handle(Collider first, Collider second)
        {
            if (first is Player && second is Player)
                Handle();
        }

        private void Handle()
        {
            throw new NotImplementedException();
        }
    }
}
