using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Roles;
using ApplicationCore.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User User, Role Role)
        {
            try
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                    new Claim(ClaimTypes.Email, User.Email),
                    new Claim(ClaimTypes.Role, Role.Name)
                };

                var jwtSettings = _configuration.GetSection("JwtSettings");

                var secretKey = jwtSettings["SecretKey"];
                var validIssuer = jwtSettings["ValidIssuer"];
                var validAudience = jwtSettings["ValidAudience"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddHours(1);

                var token = new JwtSecurityToken(
                    validIssuer,
                    validAudience,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
