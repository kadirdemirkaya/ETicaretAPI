namespace ETicaretAPI.signalr.ReceiveFuncNames
{
    public static class ReceiveFunctions
    {
        public const string ProductAddedMessage = "receiveProductAddedMessage";
        public const string LoginMessage = "loginAuthenticationMessahe";
        public const string ConnectionMessage = "connectionMessage";
        public const string ActiveCommunicationForUserMessage = "activeCommunicationForUserMessage";
        public const string ActiveCommunicationsForPersonMessage = "activeCommunicationsForPersonMessage";

        public const string ActiveCommunicationForUserData = "activeCommunicationForUserData";
        public const string ActiveCommunicationsForPersonData = "activeCommunicationsForPersonData";

        public const string CommunicationCustomerPersonForUser = "communicationCustomerPersonForUser";
        public const string CommunicationCustomerPersonForPerson = "communicationCustomerPersonForPerson";

        public const string ReceiveChatMessage = "receiveChatMessage";
    }
}
