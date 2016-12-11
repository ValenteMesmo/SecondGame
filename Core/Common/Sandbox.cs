using System;
using Common.GameComponents.MonsterComponents;
using Common.GameComponents.PlayerComponents;
using NetworkStuff;

namespace Common
{
    public class Sandbox
    {
        public readonly Event<string> Log = new Event<string>();
        public readonly Event<Player> PlayerUpdate = new Event<Player>();
        public readonly Event<Player> PlayerUpdateAfterCollisions = new Event<Player>();
        public readonly Event<Collider> ColliderCreated = new Event<Collider>();
        public readonly Event OnWorldUpdate = new Event();
        public readonly Event OnCollisionDetectionRequested = new Event();
        public readonly Event OnWorldUpdateAfterCollisions = new Event();
        public readonly Event<Collider> CollisionFromTheLeft = new Event<Collider>();
        public readonly Event<Collider> CollisionFromTheRight = new Event<Collider>();
        public readonly Event<Collider> CollisionFromAbove = new Event<Collider>();
        public readonly Event<Collider> CollisionFromBelow = new Event<Collider>();
        public readonly Event<Collider> CollisionFromAnySide = new Event<Collider>();
        public readonly Event<Collider> ColliderDestroyed = new Event<Collider>();
        public readonly Event<Collider> GroundCreated = new Event<Collider>();
        public readonly Event<Position> GroundAdded = new Event<Position>();
        public readonly Event<Position> MonsterAdded = new Event<Position>();
        public readonly Event<Monster> MonsterUpdate = new Event<Monster>();
        public readonly Event<Monster> MonsterCreated = new Event<Monster>();
        public readonly Event<bool> LeftPressed = new Event<bool>();
        public readonly Event<bool> RightPressed = new Event<bool>();
        public readonly Event<bool> UpPressed = new Event<bool>();
        public readonly Event<Position> PositionReceivedFromClient = new Event<Position>();
        public readonly Event<Address> ServerEvents_PlayerConnected = new Event<Address>();
        public readonly Event<Position> ClientEvents_PlayerCreating = new Event<Position>();
        public readonly Event<Collider> ClientEvents_PlayerCreated = new Event<Collider>();
        public readonly Event<string> ServerEvents_PlayerAdded = new Event<string>();
        public readonly Event<string> ClinetEvents_OtherPlayerAdded = new Event<string>();
        public readonly Event<Position> OtherPlayerPositionChanged = new Event<Position>();
    }
}