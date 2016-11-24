using Common.PubSubEngine;

namespace Common.GameComponents.Multiplayer
{
    public class Guest
    {
        public readonly Collider Body;
        private readonly Sandbox Sandbox;

        public Guest(Sandbox sandbox, float x, float y, string hostIp)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6, GetType());
            Sandbox.NetwokMessageReceived.Subscribe(OnMessageReceivedFromHost, hostIp);
        }

        private void OnMessageReceivedFromHost(string message)
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
