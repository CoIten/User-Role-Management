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
        public Task<Role> GetRoleById(int roleId);
        public Task<List<Role>> GetAllRoles();
        public void CreateRole(Role role);
        public void UpdateRole(Role role);
        public void DeleteRole(int roleId);
    }
}
