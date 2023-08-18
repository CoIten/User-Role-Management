using ApplicationCore.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repos
{
    public interface IPermissionRepository
    {
        public Task<Permission> GetPermissionById(int permissionId);
        public Task<List<Permission>> GetAllPermissions();
        public void CreatePermission(Permission permission);
        public void UpdatePermission(Permission permission);
        public void DeletePermission(int permissionId);
    }
}
