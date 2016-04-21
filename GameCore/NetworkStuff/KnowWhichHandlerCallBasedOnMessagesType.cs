using System;

namespace NetworkStuff
{
    public class KnowWhichHandlerCallBasedOnMessagesType
    {
        private readonly Action<string> WhenReceivingMessageOfTypeA;
        private readonly Action<string> WhenReceivingMessageOfTypeB;
        private readonly Action<string> WhenReceivingMessageOfTypeC;

        public KnowWhichHandlerCallBasedOnMessagesType(
            Action<string> whenReceivingMessageOfTypeA,
            Action<string> whenReceivingMessageOfTypeB,
            Action<string> whenReceivingMessageOfTypeC)
        {
            WhenReceivingMessageOfTypeA = whenReceivingMessageOfTypeA;
            WhenReceivingMessageOfTypeB = whenReceivingMessageOfTypeB;
            WhenReceivingMessageOfTypeC = whenReceivingMessageOfTypeC;
        }

        public void Handle(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new Exception("The message can not be empty!");

            //var actualMessage = message.Remove(0, 1);

            switch (message[0])
            {
                case '0':
                    WhenReceivingMessageOfTypeA(message);
                    break;
                case '1':
                    WhenReceivingMessageOfTypeB(message);
                    break;
                case '2':
                    WhenReceivingMessageOfTypeC(message);
                    break;
                default:
                    throw new Exception(
                        string.Format(
                            "The message cannot start with '{0}'",
                            message[0]));
            }
        }
    }
}
