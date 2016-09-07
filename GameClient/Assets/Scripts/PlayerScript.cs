using UnityEngine;
using Common;

public class PlayerScript : MonoBehaviour
{
    public Transform armTransform;
    public WorldComponent World;

    void Start()
    {
        World.Reference.AddPlayer(OnPlayerUpdated);
    }

    BoxCollider2D colliderJustToVisualize;

    private void OnPlayerUpdated(Player player)
    {
        transform.position = 
            new Vector2(player.Body.X, player.Body.Y);
        if (colliderJustToVisualize == null)
        {
            colliderJustToVisualize = gameObject.AddComponent<BoxCollider2D>();
            colliderJustToVisualize.size = new Vector2(
                player.Body.Width,
                player.Body.Height);
            colliderJustToVisualize.isTrigger = true;
        }
    }
}
