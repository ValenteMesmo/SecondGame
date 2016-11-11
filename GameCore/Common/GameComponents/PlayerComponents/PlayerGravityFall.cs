using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerGravityFall
    {
        public const float VELOCITY = 0.02f;
        public const float MAX_SPEED = 0.6f;

        public PlayerGravityFall(Sandbox sandbox)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player obj)
        {
            obj.VerticalSpeed -= VELOCITY;
            if (obj.VerticalSpeed < -MAX_SPEED)
                obj.VerticalSpeed = -MAX_SPEED;

            obj.Body.Y += obj.VerticalSpeed;
        }
    }
}
