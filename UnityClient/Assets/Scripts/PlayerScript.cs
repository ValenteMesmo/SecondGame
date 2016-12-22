using UnityEngine;
using Common;
using Common.GameComponents.PlayerComponents;

public class PlayerScript : MonoBehaviour
{
    public Transform armTransform;

    void Start()
    {
        WorldComponent.Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdated);
    }

    BoxCollider2D colliderJustToVisualize;

    private void OnPlayerUpdated(Player player)//, float interpolation)
    {
        transform.position =
            new Vector2(
               player.Body.X,
               player.Body.Y);

        if (colliderJustToVisualize == null)
        {
            WorldComponent.Sandbox.CollisionFromTheLeft.Subscribe(collider =>
            {
            }, player.Body.Name);

            colliderJustToVisualize = gameObject.AddComponent<BoxCollider2D>();
            colliderJustToVisualize.size = new Vector2(
                player.Body.Width,
                player.Body.Height);
            colliderJustToVisualize.isTrigger = true;
        }
    }
}
