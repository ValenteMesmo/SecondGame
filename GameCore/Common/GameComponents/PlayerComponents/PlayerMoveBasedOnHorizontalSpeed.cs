

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerMoveBasedOnHorizontalSpeed
    {
        public PlayerMoveBasedOnHorizontalSpeed(Sandbox sandbox)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player player)
        {
            player.Body.X += player.HorizontalSpeed;
        }
    }
}
