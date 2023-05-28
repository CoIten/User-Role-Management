﻿using ApplicationCore.Models.Users;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models.Users;
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

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUserById([FromBody] int userId)
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
            // Call the user service to retrieve a list of users
            var users = await _userService.GetUsersAsync();
            if (users.IsNullOrEmpty())
            {
                return NotFound();
            }

            // Return the list of users as the HTTP response
            var usersDtos = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDtos);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserRegistrationRequestDTO registrationDTO)
        {
            var userRegistration = _mapper.Map<UserRegistration>(registrationDTO);
            var createdUser = await _userService.CreateUser(userRegistration);
            var createdUserDTO = _mapper.Map<UserDTO>(createdUser);
            return CreatedAtAction(nameof(_userService.GetUserByIdAsync), new { id = createdUserDTO.Id }, createdUserDTO);
        }
    }
}
