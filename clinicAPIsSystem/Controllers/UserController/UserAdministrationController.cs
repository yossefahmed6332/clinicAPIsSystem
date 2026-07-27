using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Interfaces.IUserService;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdministrationController : ControllerBase
    {
        private readonly IApplicationUserService _userService;

        public UserAdministrationController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPatch("{userId:int}/assign-admin")]
        public async Task<IActionResult> AssignUserAsAdmin(int userId)
        {
            await _userService.AssignUserAsAdminAsync(userId);
            return NoContent();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("by-username/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _userService.GetUserByUserNameAsync(userName);
            return Ok(user);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{userId:int}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateApplicationUserDto updatedUser)
        {
            await _userService.UpdateUserAsync(updatedUser, userId);
            return NoContent();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            return NoContent();
        }
    }
}