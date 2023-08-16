using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> GenerateToken(User User)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, User.Id),
                new Claim(ClaimTypes.)
            };
        }
    }
}
