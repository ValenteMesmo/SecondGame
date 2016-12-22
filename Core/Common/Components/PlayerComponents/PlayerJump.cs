

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerJump
    {
        public bool JumpPressed;
        public const float VELOCITY = 1.0f;

        public PlayerJump(Sandbox sandbox, string name)
        {
            sandbox.UpPressed.Subscribe(value => JumpPressed = value, name);
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate, name);
        }

        private void OnPlayerUpdate(Player player)
        {
            if (JumpPressed && player.Grounded)
            {
                player.VerticalSpeed += VELOCITY;             
            }
        }
    }
}
