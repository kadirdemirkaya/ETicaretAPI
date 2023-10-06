using ETicaretAPI.application.Abstractions.Token;
using ETicaretAPI.infrastructure.Configurations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ETicaretAPI.infrastructure.Services.Token
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret));

            var token = new JwtSecurityToken(
                issuer: jwtConfiguration.ValidIssuer,
                audience: jwtConfiguration.ValidAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
