﻿using BusinessLayer.Interfaces;
using BusinessLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int userId)
        {

        }
        public void CreateUser(User user)
        {

        }
        public void UpdateUser(User user)
        {

        }
        public void DeleteUser(int userId)
        {

        }
    }
}