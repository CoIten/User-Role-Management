using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Roles;
using ApplicationCore.Models.Users;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs.User;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet("roleId")]
        [ActionName("GetRoleByIdAsync")]
        public async Task<ActionResult<Role>> GetRoleByIdAsync(int roleId)
        {
            var role = await _roleService.GetRoleByIdAsync(roleId);
            if (role == null)
                return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole([FromBody] Role role)
        {
            var createdRole = await _roleService.CreateRole(role);
            return CreatedAtAction(nameof(this.GetRoleByIdAsync), new { roleId = createdRole.Id }, createdRole);
        }

        [HttpPut]
        public async Task<ActionResult<Role>> UpdateRole([FromBody] Role role)
        {
            var updatedRole = await _roleService.UpdateRole(role);
            return Ok(updatedRole);
        }

        [HttpDelete("{roleId}")]
        public async Task DeleteRole(int roleId)
        {
            await _roleService.DeleteRole(roleId);
        }
    }
}
