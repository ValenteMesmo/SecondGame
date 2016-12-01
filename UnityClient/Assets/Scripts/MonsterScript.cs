using Common.GameComponents.MonsterComponents;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private BoxCollider2D colliderJustToVisualize;

    void Start()
    {
        WorldComponent.Sandbox.MonsterUpdate.Subscribe(
                MonsterUpdate,
                name);
    }
    

    private void MonsterUpdate(Monster monster)
    {
        transform.position =
            new Vector2(
                monster.Collider.X,
                monster.Collider.Y);
    }
}
