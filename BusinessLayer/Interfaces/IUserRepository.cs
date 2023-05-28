using BusinessLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int userId);
        public Task<List<User>> GetUsersAsync();
        public Task<User> CreateUser(User User);
        public Task<User> UpdateUser(User User);
        public void DeleteUser(int userId);
    }
}
