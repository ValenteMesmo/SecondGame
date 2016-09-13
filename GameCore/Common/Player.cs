namespace Common
{
    public class Player
    {
        public Collider Body { get; private set; }
        public Collider Arm { get; private set; }

        public Player()
        {
            Body = new Collider();
            Arm = new Collider();
        }
    }

    public static class Player1Input
    {
        public static bool LeftIsPressed { get;  set; }
        public static bool PunchPressed { get;  set; }
        public static bool RightIsPressed { get;  set; }
    }

    public static class PlayerFuncs
    {
        private static float speed = 0.2f;        

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
                player.Body.X =
                    player.Body.X - speed * (millisecondsSinceLastUpdate / 100.0f);
            else if (Player1Input.RightIsPressed)
                player.Body.X =
                    player.Body.X + speed * (millisecondsSinceLastUpdate / 100.0f);
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