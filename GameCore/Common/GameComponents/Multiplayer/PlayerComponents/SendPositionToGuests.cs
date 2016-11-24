using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;

namespace Common.GameComponents.RemotePlayerComponents
{
    public class SendPositionToGuests
    {
        private readonly Sandbox Sandbox;

        public SendPositionToGuests(Sandbox sandbox)
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
