//using Server;
//using System;

//namespace Common.GameComponents.Factories
//{
//    internal class PlayerPositionSetWhenMessageReceivedFromClient
//    {
//        private readonly Collider Collider;
//        private readonly Sandbox Sandbox;

//        public PlayerPositionSetWhenMessageReceivedFromClient(Sandbox sandbox, Collider collider)
//        {
//            Sandbox = sandbox;
//            Collider = collider;
                
//            Sandbox.InputReceivedFromClient.Subscribe(OnMessageReceived, Collider.Name);
//        }

//        private void OnMessageReceived(PlayerInputEnum input)
//        {
           
//        }
//    }
//}