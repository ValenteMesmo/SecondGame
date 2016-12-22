

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerWarpLeftOnRightLimit
    {
        public PlayerWarpLeftOnRightLimit(Sandbox sandbox, string name)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate, name);
        }

        private void OnPlayerUpdate(Player obj)
        {
            if (obj.Body.X < -70)
            {
                obj.Body.X = 65;
            }
        }
    }
}
