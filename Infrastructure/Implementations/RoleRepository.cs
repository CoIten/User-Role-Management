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
        public async Task<Role> CreateRole(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }
        public async Task UpdateRole(Role role)
        {
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteRole(Role role)
        {
            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}
