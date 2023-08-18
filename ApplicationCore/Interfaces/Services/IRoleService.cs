using ApplicationCore.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IRoleService
    {
        public Task<Role> GetRoleByIdAsync(int RoleId);
        public Task<Role> CreateRole(Role role);
        public Task<Role> UpdateRole(Role role);
        public Task DeleteRole(int roleId);
    }
}
