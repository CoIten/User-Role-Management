using BusinessLayer.Models.Permissions;
using BusinessLayer.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPermissionRepository
    {
        public Task<Permission> GetPermissionById(int permissionId);
        public Task<List<Permission>> GetAllPermissions();
        public void CreatePermission(Permission Permission);
        public void UpdatePermission(Permission Permission);
        public void DeletePermission(int permissionId);
    }
}
