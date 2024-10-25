using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Template.Service.Api.Rest.Domain.Model;
using Template.Service.Api.Rest.EntryPoint.Web.Dtos;

namespace Template.Service.Api.Rest.Domain.UseCase.Implementation
{
    public class AuthenticateUseCase(IOptions<JwtSettings> options) : IUseCase<Task<AccessToken>, ApiUser>
    {
        private readonly JwtSettings _jwtSettings = options.Value;
        public async Task<AccessToken> Execute(ApiUser user)
        {
            if (!string.IsNullOrEmpty(user.User) && !string.IsNullOrEmpty(user.Password))
            {
                
                var token = GenerateJwtToken(user.User);
                return await Task.FromResult(new AccessToken
                {
                    MinutesOfExpiration = _jwtSettings.ExpirationInMinutes,
                    Token = token
                });
            }
            else
            {                
                throw new CustomHttpException("The credentials used are incorrect", HttpStatusCode.Unauthorized);
            }
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddMinutes(_jwtSettings.ExpirationInMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
