using Common.GameComponents;
using Common.GameComponents.MonsterComponents;
using Common.GameComponents.PlayerComponents;
using System;
using System.Linq;

namespace Common.PubSubEngine
{
    public class Sandbox
    {
        public Sandbox()
        {
            var EventFactory = new MyEventFactory();

            AddPlayer = EventFactory.Create<Position>();
            ColliderCreated = EventFactory.Create<Collider>();
            OnCollisionDetectionRequested = EventFactory.Create();
            OnWorldUpdate = EventFactory.Create();
            OnWorldUpdateAfterCollisions = EventFactory.Create();
            CollisionFromTheLeft = EventFactory.Create<Collider>();
            CollisionFromTheRight = EventFactory.Create<Collider>();
            CollisionFromAbove = EventFactory.Create<Collider>();
            CollisionFromBelow = EventFactory.Create<Collider>();
            CollisionFromAnySide = EventFactory.Create<Collider>();
            PlayerUpdate = EventFactory.Create<Player>();
            PlayerUpdateAfterCollisions = EventFactory.Create<Player>();
            AddMonster = EventFactory.Create<Position>();
            LeftPressed = EventFactory.Create<bool>();
            RightPressed = EventFactory.Create<bool>();
            UpPressed = EventFactory.Create<bool>();
            MonsterUpdate = EventFactory.Create<Monster>();
            MonsterCreated = EventFactory.Create<Monster>();
            GroundCreated = EventFactory.Create<Collider>();
            AddGround = EventFactory.Create<Dimension>();
            FoundNewIP = EventFactory.Create<string>();
            YouEnteredThePortal = EventFactory.Create<MultiplayerPortal>();
            //AddMultiplayerPortal = EventFactory.Create<string>();
            AddRemotePlayer = EventFactory.Create<string>();
            CloseThePortal = EventFactory.Create();
            PortalCreated = EventFactory.Create<string>();            
        }

        public readonly MyEvent<Position> AddPlayer;
        public readonly MyEvent<Collider> ColliderCreated;
        public readonly MyEvent OnCollisionDetectionRequested;
        public readonly MyEvent OnWorldUpdate;
        public readonly MyEvent<Collider> CollisionFromTheLeft;
        public readonly MyEvent<Collider> CollisionFromTheRight;
        public readonly MyEvent<Collider> CollisionFromAbove;
        public readonly MyEvent<Collider> CollisionFromBelow;
        public readonly MyEvent<Collider> CollisionFromAnySide;
        public readonly MyEvent<Player> PlayerUpdate;
        public readonly MyEvent<Position> AddMonster;
        public readonly MyEvent<bool> LeftPressed;
        public readonly MyEvent<bool> RightPressed;
        public readonly MyEvent<bool> UpPressed;
        public readonly MyEvent<Monster> MonsterUpdate;
        public readonly MyEvent<Monster> MonsterCreated;
        public readonly MyEvent OnWorldUpdateAfterCollisions;
        public readonly MyEvent<Player> PlayerUpdateAfterCollisions;
        public readonly MyEvent<Collider> GroundCreated;
        public readonly MyEvent<Dimension> AddGround;
        public readonly MyEvent<string> FoundNewIP;
        public readonly MyEvent<MultiplayerPortal> YouEnteredThePortal;
        //public readonly MyEvent<string> AddMultiplayerPortal;
        public readonly MyEvent<string> AddRemotePlayer;
        public readonly MyEvent<string> NetwokMessageReceived;
        public readonly MyEvent<string> SendNetwokMessage;
        public readonly MyEvent CloseThePortal;
        public readonly MyEvent<string> PortalCreated;
    }
}