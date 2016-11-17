using UnityEngine;
using UnityEngine.Networking;

public class NetworkDiscovery : MonoBehaviour
{
    const int kMaxBroadcastMsgSize = 1024;

    [SerializeField]
    public int m_BroadcastPort = 47777;

    [SerializeField]
    public int m_BroadcastKey = 1000;

    [SerializeField]
    public int m_BroadcastVersion = 1;

    [SerializeField]
    public int m_BroadcastSubVersion = 1;

    public int hostId = -1;
    public bool running = false;

    byte[] msgInBuffer = null;
    HostTopology defaultTopology;

    public bool isServer;

    void Start()
    {
        WorldComponent.Sandbox.FoundNewIP.Subscribe(ip =>
        {
            Factory.CreateClient().InformYourListeningPortToHost(Ip, 1337);
        });
        Initialize();
    }

    public bool Initialize()
    {
        if (!NetworkTransport.IsStarted)
        {
            NetworkTransport.Init();
        }

        msgInBuffer = new byte[kMaxBroadcastMsgSize];

        var connectionConfig = new ConnectionConfig();
        connectionConfig.AddChannel(QosType.Unreliable);
        defaultTopology = new HostTopology(connectionConfig, 1);

        if (isServer)
            StartAsServer();
        else
            StartAsClient();

        return true;
    }

    public bool StartAsClient()
    {
        if (hostId != -1 || running)
        {
            Debug.LogWarning("NetworkDiscovery StartAsClient already started");
            return false;
        }

        hostId = NetworkTransport.AddHost(defaultTopology, m_BroadcastPort);
        if (hostId == -1)
        {
            Debug.LogError("NetworkDiscovery StartAsClient - addHost failed");
            return false;
        }

        byte error;
        NetworkTransport.SetBroadcastCredentials(hostId, m_BroadcastKey, m_BroadcastVersion, m_BroadcastSubVersion, out error);

        running = true;
        Debug.Log("StartAsClient Discovery listening");
        return true;
    }

    public bool StartAsServer()
    {
        if (hostId != -1 || running)
        {
            Debug.LogWarning("NetworkDiscovery StartAsServer already started");
            return false;
        }

        hostId = NetworkTransport.AddHost(defaultTopology, 0);
        if (hostId == -1)
        {
            Debug.LogError("NetworkDiscovery StartAsServer - addHost failed");
            return false;
        }

        byte err;
        if (!NetworkTransport.StartBroadcastDiscovery(
            hostId,
            m_BroadcastPort,
            m_BroadcastKey,
            m_BroadcastVersion,
            m_BroadcastSubVersion,
            null,
            0, 1000, out err))
        {
            Debug.LogError("NetworkDiscovery StartBroadcast failed err: " + err);
            return false;
        }

        running = true;
        Debug.Log("StartAsServer Discovery broadcasting");
        DontDestroyOnLoad(gameObject);
        return true;
    }

    //public void StopBroadcast()
    //{
    //    if (hostId == -1)
    //    {
    //        Debug.LogError("NetworkDiscovery StopBroadcast not initialized");
    //        return;
    //    }

    //    if (!running)
    //    {
    //        Debug.LogWarning("NetworkDiscovery StopBroadcast not started");
    //        return;
    //    }
    //    if (isServer)
    //    {
    //        NetworkTransport.StopBroadcastDiscovery();
    //    }

    //    NetworkTransport.RemoveHost(hostId);
    //    hostId = -1;
    //    running = false;
    //    msgInBuffer = null;
    //    Debug.Log("Stopped Discovery broadcasting");
    //}

    void Update()
    {
        if (hostId == -1)
            return;

        if (isServer)
            return;

        int connectionId;
        int channelId;
        int receivedSize;
        byte error;
        NetworkEventType networkEvent = NetworkEventType.DataEvent;

        do
        {
            networkEvent = NetworkTransport.ReceiveFromHost(hostId, out connectionId, out channelId, msgInBuffer, kMaxBroadcastMsgSize, out receivedSize, out error);
            if (networkEvent == NetworkEventType.BroadcastEvent)
            {
                NetworkTransport.GetBroadcastConnectionMessage(hostId, msgInBuffer, kMaxBroadcastMsgSize, out receivedSize, out error);

                string senderAddr;
                int senderPort;
                NetworkTransport.GetBroadcastConnectionInfo(hostId, out senderAddr, out senderPort, out error);

                OnReceivedBroadcast(senderAddr);
            }
        } while (networkEvent != NetworkEventType.Nothing);

    }

    public virtual void OnReceivedBroadcast(string fromAddress)
    {
        var ip = fromAddress.Split(':')[3];
        if (Network.player.ipAddress == ip)
            return;

        WorldComponent.Sandbox.FoundNewIP.Publish(ip);
    }
}