using BusinessLayer.Models.Roles;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        public async Task<Role> GetRoleById(int roleId)
        {

        }
        public async Task<List<Role>> GetAllRoles()
        {

        }
        public void CreateRole(Role role)
        {

        }
        public void UpdateRole(Role role)
        {

        }
        public void DeleteRole(int roleId)
        {

        }
    }
}
