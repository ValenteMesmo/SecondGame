﻿

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerWalkInTheAir
    {
        private readonly Sandbox Sandbox;
        private bool LeftIsPressed;
        private bool RightIsPressed;
        public const float VELOCITY = 0.02f;
        public const float MAX_SPEED = 0.4f;

        public PlayerWalkInTheAir(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.LeftPressed.Subscribe(value => LeftIsPressed = value);
            Sandbox.RightPressed.Subscribe(value => RightIsPressed = value);
            Sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        public void OnPlayerUpdate(Player player)
        {
            if (player.Grounded == false)
            {
                if (LeftIsPressed)
                {
                    player.HorizontalSpeed -= VELOCITY;
                    if (player.HorizontalSpeed < -MAX_SPEED)
                        player.HorizontalSpeed = -MAX_SPEED;
                }
                else if (RightIsPressed)
                {
                    player.HorizontalSpeed += VELOCITY;
                    if (player.HorizontalSpeed > MAX_SPEED)
                        player.HorizontalSpeed = MAX_SPEED;
                }
                else
                {
                    player.HorizontalSpeed = 0f;
                }
            }
        }
    }
}
