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
    public class AdminInUserController : ControllerBase
    {
        private readonly IApplicationUserService _userService;


        public AdminInUserController(IApplicationUserService userService)
        {
            _userService = userService;
        }


        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPatch("assign-admin/{userId:int}")]
        public async Task<IActionResult> AssignUserAsAdmin(int userId)
        {
            await _userService.AssignUserAsAdminAsync(userId);

            return Ok();
        }


        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("getbyID/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            
            return Ok(user);
        }
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("getbyusername/{username}")]
        public async Task<IActionResult> GetUserByUserName(string username)
        {
            var user = await _userService.GetUserByUserNameAsync(username);
            return Ok(user);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("getbyemail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("update-user/{userId:int}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateApplicationUserDto updatedUser)
        {
            await _userService.UpdateUserAsync(updatedUser, userId);
            return Ok();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("delete-user/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            return Ok();
        }



    }
}
