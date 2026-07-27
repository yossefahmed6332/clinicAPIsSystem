using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clinicAPIsSystem.Interfaces.IUserService;
using Microsoft.AspNetCore.Authorization;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.AccountantDTOs;
using System.Security.Claims;

namespace clinicAPIsSystem.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _applicationUserService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("by-username/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _applicationUserService.GetUserByUserNameAsync(userName);
            return Ok(user);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _applicationUserService.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateCurrentUser([FromBody] UpdateAccountantDto dto)
        {
            var currentUserId = GetCurrentUserId();
            await _applicationUserService.UpdateUserAsync(dto, currentUserId);
            return Ok();
        }

        [Authorize]
        [HttpDelete("me")]
        public async Task<IActionResult> DeleteCurrentUser()
        {
            var currentUserId = GetCurrentUserId();
            await _applicationUserService.DeleteUserAsync(currentUserId);
            return Ok();
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }
    }
}