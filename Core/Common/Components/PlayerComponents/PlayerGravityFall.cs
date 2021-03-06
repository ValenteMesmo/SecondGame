﻿

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerGravityFall
    {
        public const float VELOCITY = 0.04f;
        public const float MAX_SPEED = 2.0f;

        public PlayerGravityFall(Sandbox sandbox, string name)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate, name);
        }

        private void OnPlayerUpdate(Player player)
        {
            player.VerticalSpeed -= VELOCITY;
            if (player.VerticalSpeed < -MAX_SPEED)
                player.VerticalSpeed = -MAX_SPEED;

            player.Body.Y += player.VerticalSpeed;
        }
    }
}
