using NetworkStuff.MessageHandlers.Common;
using UnityEngine;

public class NetworkDiscovery2 : MonoBehaviour
{
    private IpDiscover ipFinder;

    private void Start()
    {
        ipFinder = new IpDiscover(OnNewIpFound);
    }

    private static void OnNewIpFound(string ip)
    {
        WorldComponent.Sandbox.FoundNewIP.Publish(ip);
    }

    void OnDestroy()
    {
        ipFinder.Dispose();
    }
}