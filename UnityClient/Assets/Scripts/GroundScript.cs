using Common;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    void Start()
    {
        WorldComponent.Sandbox.AddGround.Publish(
            new Dimension(
                transform.position.x, 
                transform.position.y,
                int.Parse(GetComponent<SpriteRenderer>().bounds.size.x.ToString()),
                int.Parse(GetComponent<SpriteRenderer>().bounds.size.y.ToString())));
    }
}
