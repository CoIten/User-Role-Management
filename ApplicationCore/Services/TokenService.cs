using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Users;
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
        public string GenerateToken(User User)
        {
            try
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                    new Claim(ClaimTypes.Email, User.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("need-to-get-from-configsneed-to-get-from-configsneed-to-get-from-configs"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddHours(1);

                var token = new JwtSecurityToken(
                    "payvortex.com",
                    "payvortex.clients",
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
