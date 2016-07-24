using UnityEngine;
using GameCore;
using System;

public class PlayerScript : MonoBehaviour
{
    DateTime current = DateTime.Now;
    IPlayer player;
    public float x_limit = 50;

    void Start()
    {        
        player = Factory.CreatePlayer();
    }

    void Update()
    {
        player.Update((current - DateTime.Now).Ticks);
        
        var x = player.GetX();
        //if (x > x_limit)
        //    x = x_limit;
        //if (x < -x_limit)
        //    x = -x_limit;

        transform.position = new Vector2(x, transform.position.y);
    }
}
