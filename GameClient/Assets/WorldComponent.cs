using Common;
using Common.PubSubEngine;

internal class WorldComponent : Singleton<WorldComponent>
{
    private World Reference = new World();
    public static Sandbox Sandbox
    {
        get { return Instance.Reference.Sandbox; }
    }

    void Update()
    {
        Reference.Update();
    }
}