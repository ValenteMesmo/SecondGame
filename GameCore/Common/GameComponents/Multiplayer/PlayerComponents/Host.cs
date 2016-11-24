using Common.PubSubEngine;

namespace Common.GameComponents.RemotePlayerComponents
{
    public class Host
    {
        public readonly Collider Body;
        private readonly Sandbox Sandbox;

        public Host(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6, GetType());
            Sandbox.NetwokMessageReceived.Subscribe(OnMessageReceivedFromClient);
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
