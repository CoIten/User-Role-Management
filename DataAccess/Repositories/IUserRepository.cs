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
        public Task<List<User>> GetAllUsers();
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
    }
}
