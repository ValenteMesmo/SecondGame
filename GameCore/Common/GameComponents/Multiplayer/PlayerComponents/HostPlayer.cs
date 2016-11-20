using Common.PubSubEngine;

namespace Common.GameComponents.RemotePlayerComponents
{
    public class HostPlayer
    {
        public Collider Body { get; }

        public HostPlayer(Sandbox sandbox, float x, float y)
        {
            Body = new Collider(sandbox, x, y, 3, 6, GetType());
            sandbox.NetwokMessageReceived.Subscribe(OnMessageReceivedFromClient);
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
