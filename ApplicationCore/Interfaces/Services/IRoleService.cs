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
        public Task<Role> GetRoleById(int RoleId);
        public void CreateRole(Role Role);
        public void UpdateRole(Role Role);
        public void DeleteRole(int RoleId);
    }
}
