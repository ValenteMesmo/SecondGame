namespace Common
{
    public struct Position
    {
        public Position(float x, float y) : this()
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }
    }

    //public class PlayerFactory
    //{
    //    private readonly Sandbox Sandbox;
    //    public PlayerFactory(Sandbox sandbox)
    //    {
    //        Sandbox = sandbox;
    //        Sandbox.Sub<Position>(
    //            EventNames.PLAYER_CREATION_REQUESTED,
    //            CreatePlayer);
    //    }

    //    private void CreatePlayer(Position position)
    //    {
    //        var player = 

         
    //    }
    //}
}
