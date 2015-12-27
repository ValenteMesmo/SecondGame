﻿using System.Collections;
using System.Collections.Generic;

public class World
{
    private ArrayList things = new ArrayList();
    public ColliderContext CollisionContext = new ColliderContext();

    System.Action<Thing> OnThingAdd;

    public World(System.Action<Thing> onThingAdd)
    {
        OnThingAdd = onThingAdd;
    }

    public void AddThing(Thing thing)
    {
        OnThingAdd(thing);
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
