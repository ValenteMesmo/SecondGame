using System.Collections.Generic;

namespace NetworkStuff.MessageHandlers
{
    public class MessageHandlersAggregator : IHandleNetworkMessages
    {
        IList<IHandleNetworkMessages> Handlers;

        public MessageHandlersAggregator(IList<IHandleNetworkMessages> handlers)
        {
            Handlers = handlers;
        }

        public void Handle(string message, Address address)
        {
            try
            {
                foreach (var handler in Handlers)
                {
                    handler.Handle(message, address);
                }
            }
            catch (System.Exception)
            {
                //TODO: Log
            }
        }
    }
}
