using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerWarpRightOnLeftLimit
    {
        public PlayerWarpRightOnLeftLimit(Sandbox sandbox)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player obj)
        {            
            if (obj.Body.X > 66)
            {
                obj.Body.X = -69;
            }
        }
    }
}
