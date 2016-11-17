using Common.PubSubEngine;

namespace Common.GameComponents.RemotePlayerComponents
{
    public class RemotePlayer
    {
        public Collider Body { get; }

        public RemotePlayer(Sandbox sandbox, float x, float y)
        {
            Body = new Collider(sandbox, x, y, 3, 6,
                GetType());
        }
    }
}
