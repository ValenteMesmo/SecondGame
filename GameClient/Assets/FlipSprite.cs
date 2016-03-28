using UnityEngine;
using System;

public class FlipSprite : MonoBehaviour
{
    public Func<bool> ShouldFlipSprite = () => false;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.flipX = ShouldFlipSprite();
    }
}
