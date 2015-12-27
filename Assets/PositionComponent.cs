using UnityEngine;
using System.Collections;
using System;

public class PositionComponent : MonoBehaviour
{
    public Func<float> Get_X;
    public Func<float> Get_Y;

    void Awake()
    {
        Get_X = Get_Y = () => 0;
    }

    void Update()
    {
        transform.position = new Vector2(Get_X(), Get_Y());
    }
}
