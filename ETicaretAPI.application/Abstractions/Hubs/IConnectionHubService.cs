namespace ETicaretAPI.application.Abstractions.Hubs
{
    public interface IConnectionHubService
    {
        Task ConnectionMessageAsync(string message);
    }
}
