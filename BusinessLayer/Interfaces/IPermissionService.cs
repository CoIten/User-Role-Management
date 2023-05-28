using ApplicationCore.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IPermissionService
    {
        public Task<Permission> GetPermissionById(int permissionId);
        public void CreatePermission(Permission Permission);
        public void UpdatePermission(Permission Permission);
        public void DeletePermission(int permissionId);
    }
}
