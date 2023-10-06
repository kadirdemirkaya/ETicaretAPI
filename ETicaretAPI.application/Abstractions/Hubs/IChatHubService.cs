using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Abstractions.Hubs
{
    public interface IChatHubService
    {
        Task SendMessageAsync(List<CommunicationMessage> message);
    }
}
