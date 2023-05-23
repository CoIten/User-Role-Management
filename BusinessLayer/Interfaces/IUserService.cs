using BusinessLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserById(int userId);
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
    }
}
