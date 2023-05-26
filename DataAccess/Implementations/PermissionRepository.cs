using BusinessLayer.Interfaces;
using BusinessLayer.Models.Permissions;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
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
        public void CreatePermission(Permission Permission)
        {
            _dbContext.Permissions.Add(Permission);
            _dbContext.SaveChanges();
        }
        public void UpdatePermission(Permission Permission)
        {
            _dbContext.Permissions.Update(Permission);
            _dbContext.SaveChanges();
        }
        public void DeletePermission(int permissionId)
        {
            var Permission = _dbContext.Permissions.FirstOrDefault(r => r.Id == permissionId);
            if (Permission != null)
            {
                _dbContext.Permissions.Remove(Permission);
                _dbContext.SaveChanges();
            }
        }
    }
}
