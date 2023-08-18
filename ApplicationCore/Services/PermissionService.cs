using ApplicationCore.Interfaces.Repos;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission> GetPermissionById(int permissionId)
        {

            return await _permissionRepository.GetPermissionById(permissionId);
        }
        public void CreatePermission(Permission permission)
        {

        }
        public void UpdatePermission(Permission permission)
        {

        }
        public void DeletePermission(int permissionId)
        {

        }
    }
}
