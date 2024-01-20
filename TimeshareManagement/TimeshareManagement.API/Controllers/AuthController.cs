using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models;
using TimeshareManagement.Models.Models.DTO;
using TimeshareManagement.Models.Role;

namespace TimeshareManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("send-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedRoles = await _authService.SeedRolesAsync();
            return Ok(seedRoles);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var register = await _authService.RegisterAsync(registerDTO);

            if (register.IsSucceed)
            {
                return Ok(register);
            }
            return BadRequest(register);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var login = await _authService.LoginAsync(loginDTO);

            if (login.IsSucceed)
            {
                return Ok(login);
            }
            return Unauthorized(login);
        }

        

        [HttpPost]
        [Route("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDTO updatePermissionDTO)
        {
            var makeAdmin = await _authService.MakeAdminAsync(updatePermissionDTO);

            if(makeAdmin.IsSucceed)
            {
                return Ok(makeAdmin);
            }
            return BadRequest(makeAdmin);
        }


        [HttpPost]
        [Route("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDTO updatePermissionDTO)
        {
            var makeOwner = await _authService.MakeOwnerAsync(updatePermissionDTO);

            if (makeOwner.IsSucceed)
            {
                return Ok(makeOwner);
            }
            return BadRequest(makeOwner);
        }

        [HttpPost]
        [Route("make-staff")]
        public async Task<IActionResult> MakeStaff([FromBody] UpdatePermissionDTO updatePermissionDTO)
        {
            var makeStaff = await _authService.MakeStaffAsync(updatePermissionDTO);

            if (makeStaff.IsSucceed)
            {
                return Ok(makeStaff);
            }
            return BadRequest(makeStaff);
        }
    }
}

