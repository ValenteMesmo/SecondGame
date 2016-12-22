

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerWarpTopOnBotLimit
    {
        public PlayerWarpTopOnBotLimit(Sandbox sandbox, string name)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate, name);
        }

        private void OnPlayerUpdate(Player obj)
        {
            if (obj.Body.Y < - 60)
            {
                obj.Body.Y = 59;
            }
        }
    }
}
