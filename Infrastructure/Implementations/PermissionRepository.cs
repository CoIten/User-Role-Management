using ApplicationCore.Interfaces.Repos;
using ApplicationCore.Models.Permissions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DataContext _dbContext;

        public PermissionRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permission> GetPermissionById(int permissionId)
        {
            return await _dbContext.Permissions.FindAsync(permissionId);
        }
        public async Task<List<Permission>> GetAllPermissions()
        {
            return await _dbContext.Permissions.ToListAsync();
        }
        public void CreatePermission(Permission permission)
        {
            _dbContext.Permissions.Add(permission);
            _dbContext.SaveChanges();
        }
        public void UpdatePermission(Permission permission)
        {
            _dbContext.Permissions.Update(permission);
            _dbContext.SaveChanges();
        }
        public void DeletePermission(int permissionId)
        {
            var permission = _dbContext.Permissions.FirstOrDefault(r => r.Id == permissionId);
            if (permission != null)
            {
                _dbContext.Permissions.Remove(permission);
                _dbContext.SaveChanges();
            }
        }
    }
}
