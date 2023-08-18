using ApplicationCore.Interfaces.Repos;
using ApplicationCore.Models.Users;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DataContext _dbContext;
        public UserRoleRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserRole> GetUserRoleByUserIdAsync(int userId)
        {
            return await _dbContext.UserRoles.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<UserRole> CreateUserRoleAsync(UserRole userRole)
        {
            await _dbContext.UserRoles.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();
            return userRole;
        }
    }
}
