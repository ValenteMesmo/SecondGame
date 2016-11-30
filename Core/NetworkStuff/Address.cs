namespace NetworkStuff
{
    public class Address
    {
        public readonly string Ip;
        public readonly int Port;

        public Address(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
    }
}
