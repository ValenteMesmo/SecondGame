using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public WorldComponent World;

    void Start()
    {
        World.Reference.AddMonster(collider =>
        {
            transform.position =
                new Vector2(
                    collider.X,
                    collider.Y);
        });
    }
}
