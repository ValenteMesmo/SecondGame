﻿using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public WorldComponent World;
    private BoxCollider2D colliderJustToVisualize;

    void Start()
    {
        World.Reference.AddMonster(
            transform.position.x,
            transform.position.y,
            collider =>
        {
            transform.position =
                new Vector2(
                    collider.X,
                    collider.Y);

            if (colliderJustToVisualize == null)
            {
                colliderJustToVisualize = gameObject.AddComponent<BoxCollider2D>();
                colliderJustToVisualize.size = new Vector2(
                    collider.Width,
                    collider.Height);
                colliderJustToVisualize.isTrigger = true;
            }
        });
    }
}
