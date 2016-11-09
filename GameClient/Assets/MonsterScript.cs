using System;
using Common;
using Common.GameComponents.MonsterComponents;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private BoxCollider2D colliderJustToVisualize;

    void Start()
    {
        WorldComponent.Sandbox
            .AddMonster.Publish(
            new Position(transform.position.x, transform.position.y));
        WorldComponent.Sandbox.MonsterCreated.Subscribe(MonsterCreated);
    }

    private void MonsterCreated(Monster monster)
    {
        Debug.Log(0);

        if (colliderJustToVisualize == null)
        {
            Debug.Log(1);

            colliderJustToVisualize = gameObject.AddComponent<BoxCollider2D>();
            colliderJustToVisualize.size = new Vector2(
                monster.Collider.Width,
                monster.Collider.Height);
            colliderJustToVisualize.isTrigger = true;

            WorldComponent.Sandbox.MonsterUpdate.Subscribe(
                MonsterUpdate, 
                monster.Collider.Name);
        }
    }

    private void MonsterUpdate(Monster monster)
    {
        transform.position =
            new Vector2(
                monster.Collider.X,
                monster.Collider.Y);
    }
}
