using System;
using Common.GameComponents;
using Common.GameComponents.MonsterComponents;
using Common.GameComponents.PlayerComponents;

namespace Common.PubSubEngine
{
    public class Sandbox
    {
        public readonly Event<Position> AddPlayer = new Event<Position>();
        public readonly Event<Collider> ColliderCreated = new Event<Collider>();
        public readonly Event OnCollisionDetectionRequested = new Event();
        public readonly Event OnWorldUpdate = new Event();
        public readonly Event<Collider> CollisionFromTheLeft = new Event<Collider>();
        public readonly Event<Collider> CollisionFromTheRight = new Event<Collider>();
        public readonly Event<Collider> CollisionFromAbove = new Event<Collider>();
        public readonly Event<Collider> CollisionFromBelow = new Event<Collider>();
        public readonly Event<Collider> CollisionFromAnySide = new Event<Collider>();
        public readonly Event<Player> PlayerUpdate = new Event<Player>();
        public readonly Event<Position> AddMonster = new Event<Position>();
        public readonly Event<bool> LeftPressed = new Event<bool>();
        public readonly Event<bool> RightPressed = new Event<bool>();
        public readonly Event<bool> UpPressed = new Event<bool>();
        public readonly Event<Monster> MonsterUpdate = new Event<Monster>();
        public readonly Event<Monster> MonsterCreated = new Event<Monster>();
        public readonly Event OnWorldUpdateAfterCollisions = new Event();
        public readonly Event<Player> PlayerUpdateAfterCollisions = new Event<Player>();
        public readonly Event<Collider> GroundCreated = new Event<Collider>();
        public readonly Event<Dimension> AddGround = new Event<Dimension>();
        public readonly Event<string> FoundNewIP = new Event<string>();
        public readonly Event<MultiplayerPortal> YouEnteredThePortal = new Event<MultiplayerPortal>();
        public readonly Event<string> AddRemotePlayer = new Event<string>();
        //public readonly Event<string> NetwokMessageReceived = new Event<string>();
        //public readonly Event<string> SendNetwokMessage = new Event<string>();
        public readonly Event CloseThePortal = new Event();
        public readonly Event<string> PortalCreated = new Event<string>();
        public readonly Event<Collider> ColliderDestroyed = new Event<Collider>();
        public readonly Event<Collider> HostPositionUpdated = new Event<Collider>();
        public readonly Event<Collider> GuestPositionUpdated = new Event<Collider>();
        public readonly Event GuestJoined = new Event();
    }
}