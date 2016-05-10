using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkStuff.MessageHandlers
{
    public class VailidateMessageLength : IHandleNetworkMessages
    {
        public void Handle(string message, Address address)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("The networkMessage cannot be empty!");

            if(message.Length <= 1)
                throw new ArgumentException("Messages should contain type prefix");
        }
    }
}
