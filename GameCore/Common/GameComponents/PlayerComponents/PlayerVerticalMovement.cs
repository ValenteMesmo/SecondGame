using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerVerticalMovement
    {
        private readonly Sandbox Sandbox;
        public float VerticalSpeed;
        public bool PunchPressed;
        public const float VELOCITY = 0.02f;
        public const float MAX_SPEED = 0.6f;

        public PlayerVerticalMovement(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.UpPressed.Subscribe(value => PunchPressed = value);
            Sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player obj)
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

            obj.Body.Y += VerticalSpeed;

            if (obj.Body.Y < 0)
            {
                VerticalSpeed = 0;
                obj.Body.Y = 0;
            }
        }
    }
}
