using ApplicationCore.Interfaces.Repos;
using ApplicationCore.Models.Roles;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _dbContext;

        public RoleRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _dbContext.Roles.FindAsync(roleId);
        }
        public async Task<List<Role>> GetAllRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }
        public async Task<Role> CreateRole(Role Role)
        {
            await _dbContext.Roles.AddAsync(Role);
            await _dbContext.SaveChangesAsync();
            return Role;
        }
        public async Task UpdateRole(Role Role)
        {
            _dbContext.Roles.Update(Role);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteRole(Role Role)
        {
            _dbContext.Roles.Remove(Role);
            await _dbContext.SaveChangesAsync();
        }
    }
}
