using ETicaretAPI.domain.Entites.Identity;

namespace ETicaretAPI.application.Abstractions.Services
{
    public interface IUserService
    {
        Task<AppUser> CurrentUserAsync();
    }
}
