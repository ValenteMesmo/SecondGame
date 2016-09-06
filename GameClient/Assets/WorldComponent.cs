using UnityEngine;
using Common;

public class WorldComponent : MonoBehaviour
{
    public World Reference = new World();

    void Update()
    {
        Reference.Update();
    }
}
