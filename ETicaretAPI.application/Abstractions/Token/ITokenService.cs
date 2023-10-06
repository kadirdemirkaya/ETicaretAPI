using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ETicaretAPI.application.Abstractions.Token
{
    public interface ITokenService
    {
        public JwtSecurityToken GetToken(List<Claim> authClaims);
    }
}
