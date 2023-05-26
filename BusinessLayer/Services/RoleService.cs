using BusinessLayer.Interfaces;
using BusinessLayer.Models.Roles;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _roleRepository.GetRoleById(roleId);
        }

        public void CreateRole(Role Role)
        {

        }

        public void UpdateRole(Role Role)
        {

        }

        public void DeleteRole(int roleId)
        {

        }
    }
}
