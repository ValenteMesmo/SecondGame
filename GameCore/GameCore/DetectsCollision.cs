namespace GameCore
{
    public class DetectsCollision
    {
        public bool IsColliding(Collider first, Collider second)
        {
            if (first.X + first.Width < second.X
                || second.X + second.Width < first.X
                || first.Y + first.Height < second.Y
                || second.Y + second.Height < first.Y)
                return false;

            return true;
        }
    }
}
