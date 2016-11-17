using System;

namespace NetworkStuff.MessageHandlers.Common
{
    public class ActualMessageReceived : IHandleNetworkMessages
    {
        private readonly Action<string, Address> MessageReceived;

        public ActualMessageReceived(Action<string, Address> messageReceived)
        {
            MessageReceived = messageReceived;
        }

        public void Handle(string message, Address address)
        {
            if (message[0] == MessageConstants.ACTUAL_MESSAGE_PREFIX)
                MessageReceived(message.Substring(1), address);
        }
    }
}
