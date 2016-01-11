using UnityEngine;
using System.Text;
using System;
using System.Net;
using System.Net.Sockets;

public class CHAT : MonoBehaviour
{
    //private Socket socket;
    //EndPoint ipLocalEndPoint, ipRemoteEndPoint;

    ////logic
    //static bool conn = false;
    //static bool arrievedX = false;

    //string xIsHere;

    //void Start()
    //{
    //    socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    //    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
    //    ipLocalEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.8"), Convert.ToInt32("5050"));
    //    socket.Bind(ipLocalEndPoint);
    //    ipRemoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.9"), Convert.ToInt32("5040"));
    //    socket.Connect(ipRemoteEndPoint);
    //    conn = true;
    //    Debug.Log("COnnected");

    //    Logger2.Log(GetLocalIPAddress());
    //}

    //void Update()
    //{
    //    byte[] buffer = new byte[1500];
    //    socket.BeginReceiveFrom(
    //        buffer,
    //        0,
    //        buffer.Length,
    //        SocketFlags.None,
    //        ref ipRemoteEndPoint,
    //        new AsyncCallback(MessageCAllBack),
    //        buffer);

    //    if (arrievedX)
    //    {

    //    }

    //    if (!connecting)
    //    {
    //        if (Input.GetKey("1"))
    //        {
    //            connecting = true;

    //        }
    //        else if (Input.GetKey("2"))
    //        {

    //        }
    //    }
    //}

    //void OnGUI()
    //{
    //    if (arrievedX)
    //    {
    //        GUI.Box(new Rect(100, 100, 100, 25), "X is here");
    //    }
    //    if (conn)
    //    {
    //        GUI.Box(new Rect(100, 50, 100, 50), "Connected");
    //    }
    //}

    //private void MessageCAllBack(IAsyncResult aResult)
    //{
    //    try
    //    {
    //        int size = socket.EndReceiveFrom(aResult, ref ipRemoteEndPoint);

    //        if (size > 0)
    //        {
    //            byte[] receivedData = new byte[1464];
    //            receivedData = (byte[])aResult.AsyncState;

    //            ASCIIEncoding eEncoding = new ASCIIEncoding();
    //            string receivedMessage = eEncoding.GetString(receivedData);
    //            //bn3mal if statement bnshof weslat el X wela la2 w iza weslat bnmasi el tabeh

    //            if (receivedMessage.Contains("x"))
    //            {
    //                Debug.Log("X is here");
    //                arrievedX = true;
    //            }

    //            //b3deen bntba3 el msg bs b7aletna bdna n5li el touch active.
    //            //ListMessage.Items.Add("Sender:" + receivedMessage);
    //        }

    //        byte[] buffer = new byte[1500];
    //        socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ipRemoteEndPoint, new AsyncCallback(MessageCAllBack), buffer);
    //    }
    //    catch (Exception exp)
    //    {
    //        Debug.Log(exp.ToString());
    //    }
    //}




    public void Start() {
        TcpListener sadsa = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), 4478);


    }




















    bool isCOnnected()
    {
        return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
    }

    public  string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("Local IP Address Not Found!");
    }

    bool connecting = false;

}

public static class Logger2
{
    static GUIText btnTexts;
    public static void Log(string msg)
    {
        if (btnTexts == null)
        {
            GameObject go = new GameObject("GUIText");
            btnTexts = go.AddComponent<GUIText>();
            go.transform.position = new Vector3(0.0f, 0.9f, 0.0f);
            btnTexts.fontSize = 40;
        }
        btnTexts.text = msg;
    }

}