

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerWarpRightOnLeftLimit
    {
        public PlayerWarpRightOnLeftLimit(Sandbox sandbox, string name)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate, name);
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
