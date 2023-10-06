using ETicaretAPI.application.DTOs.Authenticate;

namespace ETicaretAPI.application.Abstractions.Services
{
    public interface IAuthenticateService
    {
        Task<(string token, bool isSuccess,bool? TFA)> LoginAsync(LoginDto loginDto);

        Task<bool> RegisterAsync(RegisterDto registerDto);

        Task<(string token,bool isSuccess)> LoginWithTFA(string code,string email);

        Task<List<string>> GetRolesForUser(Guid UserId);
    }
}
