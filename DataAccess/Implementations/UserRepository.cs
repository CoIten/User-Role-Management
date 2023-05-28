﻿using ApplicationCore.Interfaces;
using ApplicationCore.Models.Users;
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
        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> CreateUser(User User)
        {
            await _dbContext.Users.AddAsync(User);
            await _dbContext.SaveChangesAsync();
            return User;
        }
        public async Task<User> UpdateUser(User User)
        {
            _dbContext.Users.Update(User);
            await _dbContext.SaveChangesAsync();
            return User;
        }
        public void DeleteUser(int userId)
        {
            _dbContext.SaveChanges();
        }
    }
}
