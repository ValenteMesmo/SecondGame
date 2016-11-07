using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerHorizontalMovement
    {
        private readonly Sandbox Sandbox;
        private bool LeftIsPressed;
        private bool RightIsPressed;
        public float HorizontalSpeed;
        public const float VELOCITY = 0.02f;
        public const float MAX_SPEED = 0.6f;

        public PlayerHorizontalMovement(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.LeftPressed.Subscribe(value => LeftIsPressed = value);
            Sandbox.RightPressed.Subscribe(value => RightIsPressed = value);
            Sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player obj)
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

            obj.Body.X += HorizontalSpeed;
        }
    }
}
