using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class Player
    {
        public Collider Body { get; private set; }
        public float HorizontalSpeed;
        public float VerticalSpeed;
        Sandbox Sandbox;

        public Player(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6);

            sandbox.WorldUpdate.Subscribe(Update);
            sandbox.LeftPressed.Subscribe(value => LeftIsPressed = value);
            sandbox.RightPressed.Subscribe(value => RightIsPressed = value);
            sandbox.UpPressed.Subscribe(value => PunchPressed = value);
        }

        private const float VELOCITY = 0.02f;
        private const float MAX_SPEED = 0.6f;
        private bool PunchPressed;
        private bool LeftIsPressed;
        private bool RightIsPressed;

        private void Update()
        {
            UpdateHorizontalPosition();
            UpdateVerticalPosition();
            Sandbox.PlayerUpdate.Publish(this);
        }

        private void UpdateVerticalPosition()
        {
            if (PunchPressed)
            {
                VerticalSpeed += VELOCITY;
                if (VerticalSpeed > MAX_SPEED)
                    VerticalSpeed = MAX_SPEED;
            }
            else
            {
                VerticalSpeed -= VELOCITY;
                if (VerticalSpeed < -MAX_SPEED)
                    VerticalSpeed = -MAX_SPEED;
            }
        }

        private void UpdateHorizontalPosition()
        {
            if (LeftIsPressed)
            {
                HorizontalSpeed -= VELOCITY;
                if (HorizontalSpeed < -MAX_SPEED)
                    HorizontalSpeed = -MAX_SPEED;
            }
            else if (RightIsPressed)
            {
                HorizontalSpeed += VELOCITY;
                if (HorizontalSpeed > MAX_SPEED)
                    HorizontalSpeed = MAX_SPEED;
            }
            else
            {
                HorizontalSpeed = 0f;
            }
            Body.X += HorizontalSpeed;
            Body.Y += VerticalSpeed;

            if (Body.Y < 0)
            {
                VerticalSpeed = 0;
                Body.Y = 0;
            }
        }
    }
}