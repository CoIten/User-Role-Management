using BusinessLayer.Models.Roles;
using BusinessLayer.Models.Users;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public void CreateUser(User User)
        {
            _dbContext.Users.Add(User);
            _dbContext.SaveChanges();
        }
        public void UpdateUser(User User)
        {
            _dbContext.Users.Update(User);
            _dbContext.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            _dbContext.SaveChanges();
        }
    }
}
