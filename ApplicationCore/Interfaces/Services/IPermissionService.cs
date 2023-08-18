using ApplicationCore.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IPermissionService
    {
        public Task<Permission> GetPermissionById(int permissionId);
        public void CreatePermission(Permission permission);
        public void UpdatePermission(Permission permission);
        public void DeletePermission(int permissionId);
    }
}
