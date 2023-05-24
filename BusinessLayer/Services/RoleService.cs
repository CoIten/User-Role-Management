using BusinessLayer.Interfaces;
using BusinessLayer.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRespsitory _roleRepository;

        public RoleService(IRoleReposiory roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<Role> GetRoleById(int RoleId)
        {

        }

        public void CreateRole(Role Role)
        {

        }

        public void UpdateRole(Role Role)
        {

        }

        public void DeleteRole(int RoleId)
        {

        }
    }
}
