using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;

namespace Common.GameComponents.Multiplayer
{
    public class SendPostionToHost
    {
        private readonly Sandbox Sandbox;
        
        public SendPostionToHost(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(PlayerUpdate);            
        }

        private void PlayerUpdate(Player player)
        {
            Sandbox.SendNetwokMessage.Publish(
                string.Format(
                    "cord;{0};{1}",
                    player.Body.X,
                    player.Body.Y));
        }        
    }
}
