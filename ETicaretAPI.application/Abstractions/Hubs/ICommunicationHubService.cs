using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Abstractions.Hubs
{
    public interface ICommunicationHubService
    {
        Task SendMessageForUser(string message);
        Task SendMessageForPerson(string message);


        Task SendDataForUser();
        Task SendDataForPerson();
    }
}
