using Common;
using Common.PubSubEngine;
using UnityEngine;

internal class WorldComponent : MonoBehaviour
{
    private World Reference;
    private static WorldComponent Instance;

    public static Sandbox Sandbox
    {
        get
        {
            if (Instance == null)
            {
                GameObject singleton = new GameObject();
                Instance = singleton.AddComponent<WorldComponent>();
                singleton.name = "(singleton) world";
                Instance.Reference = new World();
                //Instance.Reference.Sandbox.FoundNewIP.Subscribe(ip=> Debug.Log(ip));
            }
            return Instance.Reference.Sandbox;
        }
    }

    void Update()
    {
        Reference.Update();
    }
}