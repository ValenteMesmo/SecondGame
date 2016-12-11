using Common;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    GameObject Player;
    Position Position;

    void Start()
    {
        WorldComponent.Sandbox.ClientEvents_PlayerCreating.Subscribe(PlayerAdded);
    }

    private void PlayerAdded(Position position)
    {
        Position = position;
    }

    void Update()
    {
        if (Player == null && Position != null)
        {
            Player =
                (GameObject)Instantiate(Resources.Load("Prefab/Player"));
            Player.name = "Player";
            Player.transform.position = new Vector2(Position.X, Position.Y);
        }
    }
}
