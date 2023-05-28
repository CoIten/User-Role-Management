using ApplicationCore.Models.Users;
using BusinessLayer.Interfaces;
using BusinessLayer.Models.Users;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
        public async Task<User> CreateUser(UserRegistration userRegistration)
        {
            var hashedPasswordResult = HashPassword(userRegistration.Password);
            var user = new User
            {
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                UserName = userRegistration.UserName,
                Email = userRegistration.Email,
                PasswordSalt = hashedPasswordResult.PasswordSalt,
                HashedPassword = hashedPasswordResult.HashedPassword
            };
            var createdUser = await _userRepository.CreateUser(user);
            return createdUser;
        }
        public void UpdateUser(User user)
        {

        }
        public void DeleteUser(int userId)
        {

        }
        private HashedPasswordResult HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            byte[] hashed = KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8);

            return new HashedPasswordResult
            {
                HashedPassword = hashed,
                PasswordSalt = salt
            };
        }

        private class HashedPasswordResult
        {
            public byte[] PasswordSalt { get; set; }
            public byte[] HashedPassword { get; set; }
        }
    }
}
