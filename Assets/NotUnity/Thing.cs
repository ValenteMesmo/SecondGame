using System.Collections.Generic;

public class Thing
{
    private List<Something> toDoList;

    public Thing()
    {
        toDoList = new List<Something>();
    }

    public Thing Have(Something thing)
    {
        toDoList.Add(thing);
        return this;
    }

    public void DoIt(float timeSinceLastUpdate)
    {
        foreach (Something stuff in toDoList)
        {
            stuff.Do(timeSinceLastUpdate);
        }
    }
}
