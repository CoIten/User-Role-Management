using ApplicationCore.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpGet("roleId")]
        //public async Task<ActionResult<RoleDTO)>> GetRoleByIdAsync(int roleId)
        //{
        //    var role = await _roleService.GetRoleByIdAsync(roleId);
        //    if (role == null)
        //        return NotFound();
        //    var role
        //}

        //[HttpGet()]
    }
}
