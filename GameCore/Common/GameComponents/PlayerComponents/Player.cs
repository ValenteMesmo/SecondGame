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
        }

        private const float VELOCITY = 0.02f;
        private const float MAX_SPEED = 0.6f;

        private void Update()
        {
            UpdateHorizontalPosition();
            UpdateVerticalPosition();
            Sandbox.PlayerUpdate.Publish(this);
        }

        private void UpdateVerticalPosition()
        {
            if (Player1Input.PunchPressed)
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
            if (Player1Input.LeftIsPressed)
            {
                HorizontalSpeed -= VELOCITY;
                if (HorizontalSpeed < -MAX_SPEED)
                    HorizontalSpeed = -MAX_SPEED;
            }
            else if (Player1Input.RightIsPressed)
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