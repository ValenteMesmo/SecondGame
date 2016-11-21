using Common.PubSubEngine;

namespace Common.GameComponents.Multiplayer
{
    public class GuestPlayer
    {
        public Collider Body { get; }
        private readonly Sandbox Sandbox;


        public GuestPlayer(Sandbox sandbox, float x, float y, string hostIp)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6, GetType());
            sandbox.NetwokMessageReceived.Subscribe(OnMessageReceivedFromHost, hostIp);
            sandbox.OnWorldUpdate.Subscribe(Update);
        }

        private void Update()
        {
            Sandbox.SendNetwokMessage.Publish(
                string.Format(
                    "cord;{0};{1}",
                    Body.X,
                    Body.Y));
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
