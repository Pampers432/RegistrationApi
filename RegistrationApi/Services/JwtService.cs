using RegistrationApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using RegistrationApi.Contracts;
using System.Security.Claims;

namespace RegistrationApi.Services
{
    public class JwtService
    {
        private readonly JwtOptions _options;
        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("email", user.email)];
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpireMinutes)
                );

            var value = new JwtSecurityTokenHandler().WriteToken(token);
            return value;
        }
    }
}
