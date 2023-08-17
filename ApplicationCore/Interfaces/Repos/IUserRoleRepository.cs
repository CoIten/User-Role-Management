using ApplicationCore.Models.Roles;
using ApplicationCore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repos
{
    public interface IUserRoleRepository
    {
        public Task<UserRole> GetUserRoleByUserIdAsync(int userId);
        //public Task<UserRole> CreateUserRole(Role role);
        //public Task UpdateRole(Role role);
        //public Task DeleteRole(Role Role);
    }
}
