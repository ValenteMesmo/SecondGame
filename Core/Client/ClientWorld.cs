using Common;
using Common.GameComponents;

namespace Client
{
    public class ClientWorld : World
    {
        public ClientWorld()
        {
            //Disposables.Add(new MultiplayerMessageListener(Sandbox, 1337));
        }

        protected override void Initialize()
        {
            base.Initialize();
            Sandbox.PlayerAdded.Publish(new Position(4, 4));
        }
    }
}
