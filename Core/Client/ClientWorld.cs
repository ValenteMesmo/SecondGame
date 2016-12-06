using Common;
using Common.GameComponents;
using Common.GameComponents.Factories;

namespace Client
{
    public class ClientWorld : World
    {
        public ClientWorld()
        {   
            //Disposables.Add(new MultiplayerMessageListener(Sandbox, 1337));
            new ClientPlayerFactory(Sandbox);
        }

        protected override void Initialize()
        {
            base.Initialize();
            Sandbox.ClientEvents_PlayerAdded.Publish(new Position(4, 4));
        }
    }
}
