using ApplicationCore.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repos
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleByIdAsync(int roleId);
        public Task<List<Role>> GetAllRoles();
        public Task<Role> CreateRole(Role role);
        public Task UpdateRole(Role role);
        public Task DeleteRole(Role role);
    }
}
