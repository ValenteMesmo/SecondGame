using Core;
using NetworkStuff.Client;
using System;

namespace ClientSide
{
    //ter um metodo que é chamado sempre que uma nova coisa é criada no mundo.
    //... sempre que um objeto é criado, devolve uma funcao que retorna posicao e spritename?
    //ter um metodo para cada input do usuario: < ^ > v A B C
    public class GameClient : IDisposable
    {
        private NetworkClient networkClient;
        private World world;
        private Action<Thing> SomethingChanged;

        public GameClient(Action<Thing> somethingChanged)
        {
            SomethingChanged = somethingChanged;
            world = new World(SomethingChanged);
            world.AddThing(new Player("a", new ColliderContext()));
            
            networkClient = new NetworkClient();
        }

        public bool IsConnected()
        {
            return true;
        }

        public void Connect(string hostIp, int hostPort)
        {
            try
            {                
                networkClient.Connect(hostIp, hostPort);
                Utils.RunInBackground(ReadsMessagesFromServerForever);
            }
            catch (Exception ex)
            {
                //var newNetwork = new NetworkClient();         
                networkClient.Dispose();
            }
        }

        private void ReadsMessagesFromServerForever()
        {
            while (true)
            {
                var msgs = networkClient.Read();
                foreach (var msg in msgs)
                {
                    //THIS IS A BUG
                    var values = msg.Split(new char[] { '|' },StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length >= 3 && values[2] != "-")
                        world.UpdateThing(
                            values[0],
                            float.Parse(values[1].Replace(",", ".")),
                            float.Parse(values[2].Replace(",", ".")),
                            0,
                            0);
                }
            }
        }

        public void Dispose()
        {
            networkClient.Dispose();
            world.Dispose();
        }
    }
}
