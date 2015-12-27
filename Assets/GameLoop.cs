using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public World World;

    public GameObject PlayerPrefab;
    public GameObject BlockPrefab;

    void Awake()
    {
        if (PlayerPrefab == null)
            throw new System.NullReferenceException("PlayerPrefab cannot be null!");

        if (BlockPrefab == null)
            throw new System.NullReferenceException("BlockPrefab cannot be null!");

        World = new World(OnThingAdd);
    }

    private void OnThingAdd(Thing newThing)
    {
        if (newThing is Player)
        {
            var go = Instantiate(PlayerPrefab);
            var comp = go.AddComponent<PositionComponent>();
            comp.Get_X = () => newThing.X.GetValue();
            comp.Get_Y = () => newThing.Y.GetValue();
        }
        else if (newThing is Block)
        {
            var go = Instantiate(BlockPrefab);
            var comp = go.AddComponent<PositionComponent>();
            comp.Get_X = () => newThing.X.GetValue();
            comp.Get_Y = () => newThing.Y.GetValue();
        }
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