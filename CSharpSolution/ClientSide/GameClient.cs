using System;

namespace ClientSide
{
    //ter um metodo que é chamado sempre que uma nova coisa é criada no mundo.
    //... sempre que um objeto é criado, devolve uma funcao que retorna posicao e spritename?
    //ter um metodo para cada input do usuario: < ^ > v A B C
    public class GameClient : IDisposable
    {
        private NetworkClient network;
        private World world;
        private Action<Thing> SomethingChanged;

        public GameClient(Action<Thing> somethingChanged)
        {
            SomethingChanged = somethingChanged;

            network = new NetworkClient();
            network.HandleMessageFromServer = ServerMessageHandler;

            world = new World(SomethingChanged_Callback);
        }

        private void SomethingChanged_Callback(Thing thing)
        {
            SomethingChanged(thing);
        }

        public bool IsConnected()
        {
            return true;
        }

        public void Connect(string hostIp, int hostPort)
        {
            network.Connect(hostIp, hostPort);
        }

        private void ServerMessageHandler(string message)
        {
            var values = message.Split('|');
            world.UpdateThing(
                values[0],
                float.Parse(values[1]),
                float.Parse(values[2]),
                float.Parse(values[3]),
                float.Parse(values[4])
            );
        }

        public void Dispose()
        {
            network.Dispose();
            world.Dispose();
        }
    }
}
