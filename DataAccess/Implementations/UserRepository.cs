using BusinessLayer.Models.Users;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserById(int userId)
        {

        }
        public async Task<List<User>> GetAllUsers()
        {

        }
        public void CreateUser(User User)
        {

        }
        public void UpdateUser(User User)
        {

        }
        public void DeleteUser(int userId)
        {

        }
    }
}
