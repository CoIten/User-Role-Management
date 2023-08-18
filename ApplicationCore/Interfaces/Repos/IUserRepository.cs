using ApplicationCore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repos
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int userId);
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> CreateUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(User user);
    }
}
