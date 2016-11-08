using Common;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{    
    private BoxCollider2D colliderJustToVisualize;

    void Start()
    {
        WorldComponent.Sandbox
            .AddMonster.Publish(
            new Position(transform.position.x, transform.position.y));
        WorldComponent.Sandbox.MonsterUpdate.Subscribe(
            monster=>
        {
            transform.position =
                new Vector2(
                    monster.Collider.X,
                    monster.Collider.Y);

            if (colliderJustToVisualize == null)
            {
                colliderJustToVisualize = gameObject.AddComponent<BoxCollider2D>();
                colliderJustToVisualize.size = new Vector2(
                    monster.Collider.Width,
                    monster.Collider.Height);
                colliderJustToVisualize.isTrigger = true;
            }
        });
    }
}
