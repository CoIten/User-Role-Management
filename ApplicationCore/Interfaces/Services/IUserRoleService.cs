using ApplicationCore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IUserRoleService
    {
        public Task<UserRole> GetUserRoleByUserIdAsync(int userId);
    }
}
