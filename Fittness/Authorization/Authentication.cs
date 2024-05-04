using Fittness.Dtos.UserDtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fittness.Authorization
{
    public class Authentication : IAuthentication<UserDto>
    {
        private readonly IConfiguration _Configuration;
        public Authentication(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public string GetJsonWebToken(UserDto entity)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId,entity.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,entity.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName,entity.Email),
                new Claim("UserType", entity.UserType.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var Token = new JwtSecurityToken(
                issuer: _Configuration["Jwt:Issuer"],
                audience: _Configuration["Jwt:Audience"],
                claims: claims,
                expires: Convert.ToDateTime(DateTime.Now.AddDays(1)),
                signingCredentials: Credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
