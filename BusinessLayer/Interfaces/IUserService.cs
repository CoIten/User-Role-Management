using ApplicationCore.Models.Users;
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
        public Task<User> GetUserByIdAsync(int userId);
        public Task<List<User>> GetUsersAsync();
        public Task<User> CreateUser(UserRegistration user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
    }
}
