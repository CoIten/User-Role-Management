using BusinessLayer.Interfaces;
using BusinessLayer.Models.Users;
using DataAccess.Repositories;
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

            return await _userRepository.GetUserById(userId);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
        public async Task<User> CreateUser(User user)
        {
            var createdUser = await _userRepository.CreateUser(user);
            return createdUser;
        }
        public void UpdateUser(User user)
        {

        }
        public void DeleteUser(int userId)
        {

        }
    }
}
