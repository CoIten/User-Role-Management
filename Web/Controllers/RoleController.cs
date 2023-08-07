using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Roles;
using ApplicationCore.Models.Users;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs.User;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<Role>> CreateRole([FromBody] Role Role)
        {
            var createdRole = await _roleService.CreateRole(Role);
            return CreatedAtAction(nameof(this.GetRoleByIdAsync), new { roleId = createdRole.Id }, createdRole);
        }

        [HttpPut]
        public async Task<ActionResult<Role>> UpdateRole([FromBody] Role Role)
        {
            var updatedRole = await _roleService.UpdateRole(Role);
            return Ok(updatedRole);
        }

        [HttpDelete("{roleId}")]
        public async Task DeleteRole(int roleId)
        {
            await _roleService.DeleteRole(roleId);
        }
    }
}
