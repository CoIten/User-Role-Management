using ApplicationCore.Interfaces.Repos;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _roleRepository.GetRoleByIdAsync(roleId);
        }

        public async Task<Role> CreateRole(Role Role)
        {
            var createdRole = await _roleRepository.CreateRole(Role);
            return createdRole;    
        }

        public async Task<Role> UpdateRole(Role Role)
        {
            var existentRole = await _roleRepository.GetRoleByIdAsync(Role.Id);
            if (existentRole == null)
            {
                throw new Exception("Role Not Found!");
            }

            existentRole.Name = Role.Name;

            await _roleRepository.UpdateRole(existentRole);
            return existentRole;
        }

        public async Task DeleteRole(int roleId)
        {
            var existentRole = await _roleRepository.GetRoleByIdAsync(roleId);
            if (existentRole == null)
            {
                throw new Exception("Role Not Found!");
            }

            await _roleRepository.DeleteRole(existentRole);
        }
    }
}
