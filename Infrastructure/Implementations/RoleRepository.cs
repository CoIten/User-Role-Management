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

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _dbContext.Roles.FindAsync(roleId);
        }
        public async Task<List<Role>> GetAllRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }
        public void CreateRole(Role Role)
        {
            _dbContext.Roles.Add(Role);
            _dbContext.SaveChanges();
        }
        public void UpdateRole(Role Role)
        {
            _dbContext.Roles.Update(Role);
            _dbContext.SaveChanges();
        }
        public void DeleteRole(int roleId)
        {
            var Role = _dbContext.Roles.FirstOrDefault(r => r.Id == roleId);
            if (Role != null)
            {
                _dbContext.Roles.Remove(Role);
                _dbContext.SaveChanges();
            }
        }
    }
}
