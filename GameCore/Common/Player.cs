namespace Common
{
    public class Player
    {
        public Collider Body { get; private set; }
        public Collider Arm { get; private set; }
        public float Speed;

        public Player()
        {
            Body = new Collider();
            Arm = new Collider();
        }
    }

    public static class Player1Input
    {
        public static bool LeftIsPressed { get; set; }
        public static bool PunchPressed { get; set; }
        public static bool RightIsPressed { get; set; }
    }

    public static class PlayerFuncs
    {
        private const float VELOCITY = 0.02f;
        private const float MAX_SPEED = 0.8f;

        public static void Update(this Player player, int millisecondsSinceLastUpdate)
        {
            player.UpdateHorizontalPosition(millisecondsSinceLastUpdate);
            player.UpdateArmPosition();
        }

        private static void UpdateHorizontalPosition(
            this Player player,
            int millisecondsSinceLastUpdate)
        {
            if (Player1Input.LeftIsPressed)
            {
                player.Speed -= VELOCITY;
                if (player.Speed < -MAX_SPEED)
                    player.Speed = -MAX_SPEED;
            }
            else if (Player1Input.RightIsPressed)
            {
                player.Speed += VELOCITY;
                if (player.Speed > MAX_SPEED)
                    player.Speed = MAX_SPEED;
            }
            else
            {
                player.Speed = 0f;
            }
                player.Body.X =
                    player.Body.X + player.Speed * (millisecondsSinceLastUpdate / 100.0f);
        }

        private static void UpdateArmPosition(this Player player)
        {
            if (Player1Input.PunchPressed)
                player.Arm.X = player.Body.X + 0.6f;
            else
                player.Arm.X = player.Body.X;
        }
    }
}