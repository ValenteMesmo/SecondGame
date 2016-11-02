using System;

namespace Common
{
    public class Player
    {
        public Collider Body { get; private set; }
        public float Speed;
        Sandbox Sandbox;

        public Player(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6);

            sandbox.Sub(EventNames.WORLD_UPDATE, Update);
            sandbox.Sub<Collider>(
                EventNames.COLLISION_FROM_THE_LEFT,
                OnLeftCollision,
                Body.Name);
            sandbox.Sub<Collider>(
               EventNames.COLLISION_FROM_THE_RIGHT,
               OnRightCollision,
               Body.Name);
            sandbox.Sub<Collider>(
               EventNames.COLLISION_FROM_ABOVE,
               OnTopCollision,
               Body.Name);
            sandbox.Sub<Collider>(
               EventNames.COLLISION_FROM_BELOW,
               OnBotCollision,
               Body.Name);

        }
        private void OnTopCollision(Collider other)
        {
        }
        private void OnBotCollision(Collider other)
        {
        }
        private void OnRightCollision(Collider other)
        {
            Body.X = other.X - Body.Width;

        }
        private void OnLeftCollision(Collider other)
        {
            Body.X = other.X + other.Width;
        }

        private const float VELOCITY = 0.02f;
        private const float MAX_SPEED = 0.6f;

        private void Update()
        {
            UpdateHorizontalPosition();
            Sandbox.Pub(EventNames.PLAYER_UPDATED, this);
        }

        private void UpdateHorizontalPosition()
        {
            if (Player1Input.LeftIsPressed)
            {
                Speed -= VELOCITY;
                if (Speed < -MAX_SPEED)
                    Speed = -MAX_SPEED;
            }
            else if (Player1Input.RightIsPressed)
            {
                Speed += VELOCITY;
                if (Speed > MAX_SPEED)
                    Speed = MAX_SPEED;
            }
            else
            {
                Speed = 0f;
            }
            Body.X += Speed;
        }
    }

    public static class Player1Input
    {
        public static bool LeftIsPressed { get; set; }
        public static bool PunchPressed { get; set; }
        public static bool RightIsPressed { get; set; }
    }
}