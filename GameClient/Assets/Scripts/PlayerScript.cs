using UnityEngine;
using Common;

public class PlayerScript : MonoBehaviour
{
    //GameCore.Commons.Collider myCollider = new GameCore.Commons.Collider();
    //GameCore.Commons.Collider armCollider = new GameCore.Commons.Collider();

    public Transform armTransform;
    private World world = new World();

    void Start()
    {
        world.AddPlayer(f => {
            transform.position = new Vector2(f.Body.X, f.Body.Y);
            Debug.Log(f.Body.X);
        });
    }

    void Update()
    {
        world.Update();
        
        //xxx.playerUpdate(myCollider, armCollider);
        //transform.position = new Vector2(myCollider.X, transform.position.y);
        //armTransform.position = new Vector2(armCollider.X, armCollider.Y);
        //xxx.HandleAllCollisions(new List<GameCore.Commons.Collider>());
    }
}
