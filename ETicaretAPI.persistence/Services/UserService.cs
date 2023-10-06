using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAppUserReadRepository appUserReadRepository;

        public UserService(IHttpContextAccessor httpContextAccessor, IAppUserReadRepository appUserReadRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.appUserReadRepository = appUserReadRepository;
        }

        public async Task<AppUser> CurrentUserAsync()
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser appUser = await appUserReadRepository.GetAsync(a => a.UserName == userName);
            return appUser;
        }
    }
}
