using System;
using UnityEngine;

public class RemotePlayerFactory : MonoBehaviour
{
    void Start()
    {
        WorldComponent.Sandbox.GuestPosiitonUpdate.Subscribe(UpdateGuest);
        WorldComponent.Sandbox.HostPosiitonUpdate.Subscribe(UpdateHost);
        WorldComponent.Sandbox.OtherPlayerEnteredAsTheGuest.Subscribe(NewGuest);
        WorldComponent.Sandbox.OtherPlayerEnteredAsTheHost.Subscribe(NewGuest);
    }

    bool createPLayer = false;
    private GameObject player;
    private Vector2 newPosition = new Vector2(0, 0);

    private void NewGuest()
    {
        createPLayer = true;
    }

    private void UpdateHost(Common.Collider obj)
    {
        newPosition.x = obj.X;
        newPosition.y = obj.Y;
    }

    private void UpdateGuest(Common.Collider obj)
    {
        newPosition.x = obj.X;
        newPosition.y = obj.Y;
    }

    void Update()
    {
        if (createPLayer && player == null)
            player = (GameObject)Instantiate(Resources.Load("Prefab/Other Player"));
        if (player != null)
            player.transform.position = newPosition;
    }
}
