using UnityEngine;

public class RemotePlayerFactory : MonoBehaviour
{
    void Start()
    {
        WorldComponent.Sandbox.ClinetEvents_OtherPlayerAdded.Subscribe(OtherplayerCreated);
    }

    private void OtherplayerCreated(string name)
    {
        var player = (GameObject)Instantiate(Resources.Load("Prefab/Other Player"));
        WorldComponent.Sandbox.OtherPlayerPositionChanged.Subscribe(pos =>
        {
            player.transform.position = new Vector2(pos.X, pos.Y);
        }, name);
    }

    //private readonly Dictionary<string, Vector2> positions =
    //    new Dictionary<string, Vector2>();

    //private readonly Dictionary<string, GameObject> players =
    //    new Dictionary<string, GameObject>();

    //private readonly List<string> PlayersToCreate = new List<string>();

    //private void UpdateGuest(Common.Collider obj)
    //{
    //    if (positions.ContainsKey(obj.Name) == false)
    //    {
    //        positions[obj.Name] = new Vector2(0, 0);
    //        PlayersToCreate.Add(obj.Name);
    //    }
    //    var pos = positions[obj.Name];
    //    pos.x = obj.X;
    //    pos.y = obj.Y;
    //    positions[obj.Name] = pos;
    //}

    //void Update()
    //{
    //    foreach (var name in PlayersToCreate.ToList())
    //    {
    //        PlayersToCreate.Remove(name);
    //        players[name] = (GameObject)Instantiate(Resources.Load("Prefab/Other Player"));
    //    }

    //    foreach (var name in positions.Keys.ToList())
    //    {
    //        players[name].transform.position = positions[name];
    //    }
    //}
}
