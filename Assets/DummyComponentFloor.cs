using UnityEngine;
using System.Collections;

public class DummyComponentFloor : MonoBehaviour
{

    public GameLoop game;
    VariablePosition coordinates;

    void Start()
    {
        var block = new Thing();
        var world = game.World;

        var unityCollider = GetComponent<BoxCollider2D>();

        coordinates = new VariablePosition(
              new FloatNumber(-100, 100),
              new FloatNumber(-100, 100, -2));

        var collider = new RectangleCollider(
                block,
                world.CollisionContext,
                coordinates,
                width: unityCollider.bounds.size.x,
                height: unityCollider.bounds.size.y,
                name: "Ground");

        
        
        //Debug.Log(string.Format("Ground [w: {0}, h: {1}]", unityCollider.size.x, unityCollider.size.y));


        block
            .Have(coordinates)
            .Have(collider);

        Destroy(unityCollider);

        world.AddThing(block);
    }

    void Update()
    {
        transform.position = new Vector2(
            coordinates.X.GetValue(),
            coordinates.Y.GetValue());

    }
}
