using GameCore.Commons;

namespace GameCore
{
    public interface IHandleCollision
    {
        void Handle(Collider first, Collider second);
    }
}