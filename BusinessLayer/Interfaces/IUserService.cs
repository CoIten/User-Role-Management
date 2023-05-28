﻿using ApplicationCore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByIdAsync(int userId);
        public Task<List<User>> GetUsersAsync();
        public Task<User> CreateUser(UserPost user);
        public Task<User> UpdateUser(UserUpdate userUpdate);
        public void DeleteUser(int userId);
    }
}
