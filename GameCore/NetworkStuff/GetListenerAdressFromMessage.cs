using NetworkStuff.Udp;
using System;
using System.Text.RegularExpressions;

namespace NetworkStuff
{
    public class GetListenerAdressFromMessage
    {
        public Address Get(string message, Address writersOrigin)
        {
            Regex startsWithZeroFollowedByIdAndPort =
                new Regex(@"^0\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,5}$");

            if (startsWithZeroFollowedByIdAndPort.Match(message).Success)
            {
                var ipAndPort = message.Remove(0, 1).Split(':');

                if (ipAndPort[0] != writersOrigin.Ip)
                    throw new ArgumentException(
                        @"Writer and Listener should be on the same Ip...
At least for now~");

                return new Address(
                    ipAndPort[0],
                    int.Parse(ipAndPort[1]));
            }

            throw new ArgumentException(
                string.Format(@"Message should contain ip and port '0127.0.0.1:20001', for example.
The invalid message received was '{}'", message));
        }
    }
}
