using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Web.DTOs.User;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        [ActionName("GetUserByIdAsync")]  // for "CreateUser" CreatedAtAction, because .net removes "Async" suffix and it can't find this action
        public async Task<ActionResult<UserDTO>> GetUserByIdAsync(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound();
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            if (users.IsNullOrEmpty())
            {
                return NotFound();
            }
            var usersDtos = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDtos);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserPostDTO registrationDTO)
        {
            var userRegistration = _mapper.Map<UserPost>(registrationDTO);
            var createdUser = await _userService.CreateUser(userRegistration);
            var createdUserDTO = _mapper.Map<UserDTO>(createdUser);
            return CreatedAtAction(nameof(this.GetUserByIdAsync) , new { userId = createdUserDTO.Id }, createdUserDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var userLogin = _mapper.Map<UserLogin>(userLoginDTO);
            var token = await _userService.AuthenticateAndGenerateToken(userLogin);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            var userUpdate = _mapper.Map<UserUpdate>(userUpdateDTO);
            var updatedUser = await _userService.UpdateUser(userUpdate);
            var updatedUserDTO = _mapper.Map<UserDTO>(updatedUser);
            return Ok(updatedUserDTO);
        }

        [HttpDelete("{userId}")]
        [Authorize]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
    }
}
