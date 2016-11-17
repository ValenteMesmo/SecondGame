using NetworkStuff.Udp;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NetworkStuff.MessageHandlers.Common;
using System.Text;

namespace NetworkStuff.MessageHandlers
{
    public class ConnectionAttemptMessageHandler : IHandleNetworkMessages
    {
        private readonly ISendNetworkMessages Writer;
        private readonly IList<Address> ConnectedClients;
        private readonly IListenToNetworkMessages Listener;

        public ConnectionAttemptMessageHandler(
            ISendNetworkMessages writer,
            IListenToNetworkMessages listener,
            IList<Address> connectedClients)
        {
            Listener = listener;
            Writer = writer;
            ConnectedClients = connectedClients;
        }

        public void Handle(string message, Address address)
        {
            var match = new Regex(@"^(?<MessageType>0)(?<Ip>(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])):(?<Port>[0-9]{1,5})$")
                .Match(message);

            if (match.Success)
            {
                var listeningOnIp = match.Groups["Ip"].Value;
                var listeningOnPort = int.Parse(match.Groups["Port"].Value);

                if (ConnectedClients.Any(f =>
                     f.Ip == listeningOnIp
                     && f.Port == listeningOnPort) == false)
                {
                    ConnectedClients.Add(new Address(listeningOnIp, listeningOnPort));
                }
                
                var messageBuilder = new StringBuilder();
                messageBuilder.Append(MessageConstants.CONNECTION_RESPONSE_PREFIX);
                //Im actually not using the address included here V
                messageBuilder.Append(Listener.Ip);
                messageBuilder.Append(':');
                messageBuilder.Append(Listener.Port);
                
                Writer.Write(messageBuilder.ToString(), listeningOnIp, listeningOnPort);
            }
        }
    }
}