namespace NetworkStuff.MessageHandlers
{
    public interface IHandleNetworkMessages
    {
        void Handle(string message, Address address);
    }
}
