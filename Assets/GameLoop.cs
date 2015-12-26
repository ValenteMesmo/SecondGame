using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public World World;

    void Awake()
    {
        World = new World();
    }

    void Update()
    {
        World.UpdateEverything(Time.deltaTime);
    }
}

public class InputInfo
{
    public bool RequestingLeftMovement { get; set; }
    public bool RequestingRightMovement { get; set; }

    public bool RequestingJump { get; set; }
}
