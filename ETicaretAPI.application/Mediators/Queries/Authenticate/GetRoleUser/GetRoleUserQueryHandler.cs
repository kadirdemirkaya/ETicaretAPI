
using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.application.Mediators.Queries.Authenticate.GetRoleUser
{
    public class GetRoleUserQueryHandler : IRequestHandler<GetRoleUserQueryRequest, GetRoleUserQueryResponse>
    {
        private readonly IAuthenticateService authenticateService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;

        public GetRoleUserQueryHandler(IAuthenticateService authenticateService, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            this.authenticateService = authenticateService;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<GetRoleUserQueryResponse> Handle(GetRoleUserQueryRequest request, CancellationToken cancellationToken)
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser appUser = await userManager.FindByNameAsync(userName);
            var response = await authenticateService.GetRolesForUser(appUser.Id);
            return new() { roles = response };
        }
    }
}

