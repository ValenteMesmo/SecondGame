using UnityEngine;
using GameCore;
using System;
using GameCore.Commons;

public class PlayerScript : MonoBehaviour
{
    DateTime lastUpdate = DateTime.Now;
    //IPlayer player;
    //public float x_limit = 50;
    GameCore.Commons.Collider collider = new GameCore.Commons.Collider();
    void Start()
    {        
        //player = Factory.CreatePlayer();
    }

    void Update()
    {
        var now = DateTime.Now;
        var millisecondsSinceLastUpdate = (now - lastUpdate).Milliseconds;
        xxx.UpdateHorizontalPosition(collider, millisecondsSinceLastUpdate);
        //player.Update((current - DateTime.Now).Ticks);

        //var x = player.GetX();

        //transform.position = new Vector2(x, transform.position.y);
        transform.position = new Vector2(collider.X, transform.position.y);
        lastUpdate = now;
    }
}
