using Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo("ClientSide")]
[assembly: InternalsVisibleTo("ServerSide")]
internal class World : IDisposable
{
    public ColliderContext CollisionContext = new ColliderContext();
    private Thread physicsThread;
    private Action<Thing> OnSomthingChanged;
    private List<Thing> things = new List<Thing>();

    //TODO: use to keep changes sent by the server
    //obs: same class to client and server is starting to get wierd
    private Dictionary<string, Thing> updates = new Dictionary<string, Thing>();

    public void AddThing(Thing thing)
    {
        OnSomthingChanged(thing);
        things.Add(thing);
    }

    public World(Action<Thing> somethingChanged_Callback)
    {
        OnSomthingChanged = somethingChanged_Callback;
        StartPhysicsThread();
    }

    private void StartPhysicsThread()
    {
        long currentTime = DateTime.Now.Ticks;
        long frameTime;
        long newTime;

        physicsThread = Utils.RunInBackground(() =>
        {
            Thread.Sleep(100);//prevents weird nullreference exception

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

                    //remove?
                    OnSomthingChanged(things[i]);
                }
            }
        });
    }

    internal void UpdateThing(string id, float x, float y, float velocity_x, float velocity_y)
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
}

