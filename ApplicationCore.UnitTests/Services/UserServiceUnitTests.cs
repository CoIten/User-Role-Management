using ApplicationCore.Interfaces.Repos;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Users;
using ApplicationCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static ApplicationCore.Services.UserService;

namespace ApplicationCore.UnitTests.Services
{
    public class UserServiceUnitTests
    {
        [Fact]
        public async Task CreateUser_SuccessfulCreation_ReturnsCreatedUser()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userRoleServiceMock = new Mock<IUserRoleService>();
            var roleServiceMock = new Mock<IRoleService>();
            var tokenServiceMock = new Mock<ITokenService>();

            var userService = new UserService(userRepositoryMock.Object, userRoleServiceMock.Object,
                roleServiceMock.Object, tokenServiceMock.Object);

            var userCreation = new UserPost
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@gmail.com",
                Password = "password",
                RoleId = 2,
                UserName = "TestTest",
            };

            var hashedPasswordResult = new HashedPasswordResult
            {
                PasswordSalt = "TestSalt",
                HashedPassword = Convert.ToBase64String(RandomNumberGenerator.GetBytes(128 / 8))
            };

            userRepositoryMock.Setup(repo => repo.CreateUser(It.IsAny<User>()))
                .ReturnsAsync(new User { Id = 1, Email = userCreation.Email });

            userRoleServiceMock.Setup(serv => serv.CreateUserRoleAsync(It.IsAny<UserRole>()))
                .ReturnsAsync(new UserRole { Id = 1, RoleId = userCreation.RoleId, UserId = 2 });

            var createdUser = await userService.CreateUser(userCreation);


            Assert.NotNull(createdUser);
            Assert.Equal(userCreation.Email, createdUser.Email);
        }
    }
}
