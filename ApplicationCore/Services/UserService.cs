﻿using ApplicationCore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ApplicationCore.Interfaces.Repos;
using ApplicationCore.Interfaces.Services;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> CreateUser(UserPost userRegistration)
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

        public async Task<string?> AuthenticateAndGenerateToken(UserLogin userLogin)
        {
            var user = await _userRepository.GetUserByEmailAsync(userLogin.Email);

            if (user == null || !VerifyPasswordHash(userLogin.Password, user.PasswordSalt, user.HashedPassword))
            {
                return null;
            }

            string token = _tokenService.GenerateToken(user);
            return token;
        }

        public async Task<User> UpdateUser(UserUpdate userUpdate)
        {
            var existentUser = await _userRepository.GetUserById(userUpdate.Id);
            if (existentUser == null)
            {
                throw new Exception("User Not Found!");
            }

            existentUser.FirstName = userUpdate.FirstName;
            existentUser.LastName = userUpdate.LastName;
            existentUser.UserName = userUpdate.UserName;

            await _userRepository.UpdateUser(existentUser);
            return existentUser;
        }

        public async Task DeleteUser(int userId)
        {
            var existentUser = await _userRepository.GetUserById(userId);
            if (existentUser == null)
            {
                throw new Exception("User Not Found!");
            }

            await _userRepository.DeleteUser(existentUser);
        }

        private HashedPasswordResult HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));

            return new HashedPasswordResult
            {
                HashedPassword = hashed,
                PasswordSalt = Convert.ToBase64String(salt)
            };
        }

        private class HashedPasswordResult
        {
            public string PasswordSalt { get; set; }
            public string HashedPassword { get; set; }
        }

        private bool VerifyPasswordHash(string password, string passwordSalt, string hashedPassword)
        {
            string hashedPw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: Convert.FromBase64String(passwordSalt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));

            if (hashedPw == hashedPassword)
                return true;

            return false;
        }
    }
}
