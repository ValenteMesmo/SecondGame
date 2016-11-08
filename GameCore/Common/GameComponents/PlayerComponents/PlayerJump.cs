using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerJump
    {
        public bool JumpPressed;
        public const float VELOCITY = 1.0f;

        public PlayerJump(Sandbox sandbox)
        {
            sandbox.UpPressed.Subscribe(value => JumpPressed = value);
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player player)
        {
            if (JumpPressed && player.Body.Y == 0)
            {
                player.VerticalSpeed += VELOCITY;             
            }
        }
    }
}
