using UnityEngine;
using Common;

public class PlayerScript : MonoBehaviour
{
    //GameCore.Commons.Collider myCollider = new GameCore.Commons.Collider();
    //GameCore.Commons.Collider armCollider = new GameCore.Commons.Collider();

    public Transform armTransform;
    public WorldComponent World;

    void Start()
    {
        World.Reference.AddPlayer(OnPlayerUpdated);
    }

    private void OnPlayerUpdated(Player player)
    {
        transform.position = 
            new Vector2(player.Body.X, player.Body.Y);
        //Debug.Log(player.Body.X);
    }
}
