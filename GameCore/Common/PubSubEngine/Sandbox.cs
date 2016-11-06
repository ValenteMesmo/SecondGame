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

            CollisionFromTheLeft = EventFactory.Create<Collider>();
            CollisionFromTheRight = EventFactory.Create<Collider>();
            CollisionFromAbove = EventFactory.Create<Collider>();
            CollisionFromBelow = EventFactory.Create<Collider>();
            PlayerUpdate = EventFactory.Create<Player>();
            MonsterCreationRequested = EventFactory.Create<Position>();
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
        public readonly MyEvent<Position> MonsterCreationRequested;
    }
}