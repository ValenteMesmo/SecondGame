

//namespace Common.GameComponents.Factories
//{
//    //not used
//    public class NetworkFactory
//    {
//        private readonly Sandbox Sandbox;

//        public NetworkFactory(Sandbox sandbox)
//        {
//            Sandbox = sandbox;
//            Sandbox.FoundNewIP.Subscribe(WhenIpIsFound);
//            //Sandbox.OtherPlayerEnteredAsTheHost.Subscribe(OtherPlayerAsHost);
//            //Sandbox.OtherPlayerEnteredAsTheGuest.Subscribe(OtherPlayerAsGuest);
//        }

//        //private void OtherPlayerAsHost(string ip)
//        //{
//        //    new OtherPlayerAsGuest(Sandbox, 0, 0);            
//        //}

//        //private void OtherPlayerAsGuest(string ip)
//        //{
//        //    new OtherPlayerAsHost(Sandbox, 0, 0);
//        //}

//        private void WhenIpIsFound(string ip)
//        {
//            new MultiplayerMessageSender(Sandbox, ip, 1337);
//        }
//    }
//}
