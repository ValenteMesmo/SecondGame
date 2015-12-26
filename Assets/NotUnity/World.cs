using System.Collections;
using System.Collections.Generic;

public class World
{
    private ArrayList things = new ArrayList();
    public ColliderContext CollisionContext = new ColliderContext();

    public void AddThing(Thing thing)
    {
        things.Add(thing);
    }

    public void UpdateEverything(float timeSinceLastUpdate)
    {
        foreach (Thing thing in things)
        {
            thing.DoIt(timeSinceLastUpdate);
        }
    }
}
