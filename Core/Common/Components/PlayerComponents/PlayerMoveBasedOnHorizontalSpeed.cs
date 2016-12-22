

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerMoveBasedOnHorizontalSpeed
    {
        public PlayerMoveBasedOnHorizontalSpeed(Sandbox sandbox, string name)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate, name);
        }

        private void OnPlayerUpdate(Player player)
        {
            player.Body.X += player.HorizontalSpeed;
        }
    }
}
