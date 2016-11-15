using Common.GameComponents.MonsterComponents;
using Common.GameComponents.PlayerComponents;

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
            WorldUpdate = EventFactory.Create();
            WorldUpdateAfterCollisions = EventFactory.Create();
            CollisionFromTheLeft = EventFactory.Create<Collider>();
            CollisionFromTheRight = EventFactory.Create<Collider>();
            CollisionFromAbove = EventFactory.Create<Collider>();
            CollisionFromBelow = EventFactory.Create<Collider>();
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
        }

        public readonly MyEvent<Position> AddPlayer;
        public readonly MyEvent<Collider> ColliderCreated;
        public readonly MyEvent OnCollisionDetectionRequested;
        public readonly MyEvent WorldUpdate;
        public readonly MyEvent<Collider> CollisionFromTheLeft;
        public readonly MyEvent<Collider> CollisionFromTheRight;
        public readonly MyEvent<Collider> CollisionFromAbove;
        public readonly MyEvent<Collider> CollisionFromBelow;
        public readonly MyEvent<Player> PlayerUpdate;
        public readonly MyEvent<Position> AddMonster;
        public readonly MyEvent<bool> LeftPressed;
        public readonly MyEvent<bool> RightPressed;
        public readonly MyEvent<bool> UpPressed;
        public readonly MyEvent<Monster> MonsterUpdate;
        public readonly MyEvent<Monster> MonsterCreated;
        public readonly MyEvent WorldUpdateAfterCollisions;
        public readonly MyEvent<Player> PlayerUpdateAfterCollisions;
        public readonly MyEvent<Collider> GroundCreated;
        public readonly MyEvent<Dimension> AddGround;
        public readonly MyEvent<string> FoundNewIP;
    }
}