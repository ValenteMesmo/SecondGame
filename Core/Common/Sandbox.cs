using Common.GameComponents;
using Common.GameComponents.MonsterComponents;
using Common.GameComponents.PlayerComponents;

namespace Common
{
    public class Sandbox
    {
        public readonly Event<Position> PlayerAdded = new Event<Position>();
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
        public readonly Event<Position> GroundAdded = new Event<Position>();
        public readonly Event<string> FoundNewIP = new Event<string>();
        public readonly Event<MultiplayerPortal> YouEnteredThePortal = new Event<MultiplayerPortal>();
        public readonly Event<string> PortalDisposed = new Event<string>();
        public readonly Event<string> PortalCreated = new Event<string>();
        public readonly Event<Collider> ColliderDestroyed = new Event<Collider>();
        public readonly Event OtherPlayerEnteredAsTheGuest = new Event();
        public readonly Event OtherPlayerEnteredAsTheHost = new Event();
        public readonly Event<Collider> HostPosiitonUpdate = new Event<Collider>();
        public readonly Event<Collider> GuestPosiitonUpdate = new Event<Collider>();
    }
}