﻿using UnityEngine;
using Common;
using Common.GameComponents.PlayerComponents;

public class PlayerScript : MonoBehaviour
{
    public Transform armTransform;

    void Start()
    {
        WorldComponent.Sandbox.AddPlayer.Publish(
            new Position(transform.position.x, transform.position.y));

        WorldComponent.Sandbox.PlayerUpdate.Subscribe(OnPlayerUpdated);

        
    }

    BoxCollider2D colliderJustToVisualize;

    private void OnPlayerUpdated(Player player)//, float interpolation)
    {
        //Debug.Log(player.Speed);
        transform.position =
            new Vector2(
               player.Body.X
                ,
               player.Body.Y);

        if (colliderJustToVisualize == null)
        {
            WorldComponent.Sandbox.CollisionFromTheLeft.Subscribe(collider => {
                //Debug.Log("opa!");
            }, player.Body.Name);

            colliderJustToVisualize = gameObject.AddComponent<BoxCollider2D>();
            colliderJustToVisualize.size = new Vector2(
                player.Body.Width,
                player.Body.Height);
            colliderJustToVisualize.isTrigger = true;
        }
    }
}
