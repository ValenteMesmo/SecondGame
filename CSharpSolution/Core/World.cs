using Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

public class World : IWorld
{
    public ColliderContext CollisionContext { get; set; }
    private Thread physicsThread;
    private Action<Thing> OnSomthingChanged = thing => { };
    private List<Thing> things = new List<Thing>();

    //TODO: use to keep changes sent by the server
    //obs: same class to client and server is starting to get wierd
    private Dictionary<string, Thing> updates = new Dictionary<string, Thing>();

    public void AddThing(Thing thing)
    {
        OnSomthingChanged(thing);
        things.Add(thing);
    }

    public World()
    {
        CollisionContext = new ColliderContext();
        StartPhysicsThread();
    }

    private void StartPhysicsThread()
    {
        long currentTime = DateTime.Now.Ticks;
        long frameTime;
        long newTime;

        physicsThread = Utils.RunInBackground(() =>
        {
            Thread.Sleep(10);//prevents weird nullreference exception

            while (true)
            {
                newTime = DateTime.Now.Ticks;
                frameTime = newTime - currentTime;
                currentTime = newTime;

                for (int i = 0; i < things.Count; i++)
                {
                    var thing = things[i];
                    if (updates.ContainsKey(thing.Id))
                    {
                        thing.X = updates[thing.Id].X;
                        thing.Y = updates[thing.Id].Y;
                    }
                    things[i].DoIt(frameTime);

                    //This... ... ... ...                    
                    OnSomthingChanged(things[i]);
                }
            }
        });
    }

    public void UpdateThing(string id, float x, float y, float velocity_x, float velocity_y)
    {
        //trocar por struct?
        var sadsd = new Thing(id);
        sadsd.X.SetValue(x);
        sadsd.Y.SetValue(y);
        updates[id] = sadsd;
    }

    public void Dispose()
    {
        physicsThread.Abort();
    }

    public void SetActionToBeCalledWhenSomethingChanges(Action<Thing> action)
    {
        OnSomthingChanged = action;
    }
}
public interface IWorld : IDisposable
{
    //TODO: verify if this is really necessary
    ColliderContext CollisionContext { get; set; }

    void SetActionToBeCalledWhenSomethingChanges(Action<Thing> action);
    void AddThing(Thing thing);
    void UpdateThing(string id, float x, float y, float velocity_x, float velocity_y);
}