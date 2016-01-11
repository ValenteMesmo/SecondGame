using System;

public class Program
{
    static public void Main(string[] Args)
    {
        var client = new ClientClass("192.168.0.8", 8001);
        client.Start(message => Console.WriteLine(message));

        while (true)
        {
            var msg = Console.ReadLine();
            client.SendMessage(msg);
        }
    }
}