using UnityEngine;
using Common;

public class PlayerScript : MonoBehaviour
{
    public Transform armTransform;
    public WorldComponent World;

    void Start()
    {
        World.Reference.AddPlayer(
            transform.position.x,
            transform.position.y);
        World.Reference.Sandbox.Sub<Player>(
            EventNames.PLAYER_UPDATED, 
            OnPlayerUpdated);

        //World.Reference.Sandbox.Sub(EventNames.COLLISION_FROM_THE_LEFT,
    }

    BoxCollider2D colliderJustToVisualize;

    private void OnPlayerUpdated(Player player)//, float interpolation)
    {
        //Debug.Log(player.Speed);
        transform.position = 
            new Vector2(
               transform.position.x 
               + player.Speed//+ (player.Speed * interpolation)
                ,player.Body.Y);
        
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
