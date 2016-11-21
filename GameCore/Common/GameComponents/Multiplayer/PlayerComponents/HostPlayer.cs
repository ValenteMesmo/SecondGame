using Common.PubSubEngine;

namespace Common.GameComponents.RemotePlayerComponents
{
    public class HostPlayer
    {
        public readonly Collider Body;
        private readonly Sandbox Sandbox;

        public HostPlayer(Sandbox sandbox, float x, float y)
        {
            Body = new Collider(sandbox, x, y, 3, 6, GetType());
            Sandbox = sandbox;
            Sandbox.NetwokMessageReceived.Subscribe(OnMessageReceivedFromClient);
            Sandbox.OnWorldUpdate.Subscribe(Update);
        }

        private void Update()
        {
            Sandbox.SendNetwokMessage.Publish(
                string.Format(
                    "cord;{0};{1}",
                    Body.X,
                    Body.Y));
        }

        private void OnMessageReceivedFromClient(string message)
        {
            if (message.StartsWith("cord;"))
            {
                var split = message.Split(';');
                Body.X = float.Parse(split[1]);
                Body.Y = float.Parse(split[2]);
            }
        }
    }
}
