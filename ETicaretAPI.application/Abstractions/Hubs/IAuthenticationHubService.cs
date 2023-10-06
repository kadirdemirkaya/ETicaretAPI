namespace ETicaretAPI.application.Abstractions.Hubs
{
    public interface IAuthenticationHubService
    {
        Task LoginMessageAsync(string message);
    }
}
