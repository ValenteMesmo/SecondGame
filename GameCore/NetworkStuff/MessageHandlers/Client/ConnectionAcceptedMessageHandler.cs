﻿using NetworkStuff.MessageHandlers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkStuff.MessageHandlers
{
    public class ConnectionAcceptedMessageHandler : IHandleNetworkMessages
    {
        private readonly Action<Address> OnConnectionAccepted;

        public ConnectionAcceptedMessageHandler(Action<Address> onConnectionAccepted)
        {
            OnConnectionAccepted = onConnectionAccepted;
        }

        public void Handle(string message, Address address)
        {
            if (message[0] == MessageConstants.CONNECTION_RESPONSE_PREFIX)
            {
                OnConnectionAccepted(address);
            }
        }
    }
}
