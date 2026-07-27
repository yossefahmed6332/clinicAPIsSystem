
using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Interfaces.IUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clinicAPIsSystem.Controllers
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

        [Authorize(Roles = "Accountant")]
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _applicationUserService.GetUserByIdAsync(id);

            return Ok(user);

        }

        [Authorize(Roles = "Accountant")]
        [HttpGet]
        [Route("GetUserByUserName/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _applicationUserService.GetUserByUserNameAsync(userName);
            return Ok(user);
        }

        [Authorize(Roles = "Accountant")]
        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public async Task<IActionResult> GetUserNyEmail(string email)
        {
            var user = await _applicationUserService.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [Authorize(Roles = "User")]
        [HttpPatch]
        [Route("ChangePhoneNumber")]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] string phoneNumber)
        {
            var userId = int.Parse(
                 User.FindFirstValue(ClaimTypes.NameIdentifier)!
      );

            await _applicationUserService.ChangePhoneNumberAsync(phoneNumber, userId);

            return Ok(new
            {
                Message = "Phone number updated successfully."
            });

        }

        [Authorize(Roles = "User")]
        [HttpPatch]
        [Route("ChangeUserName")]
        public async Task<IActionResult> ChangeUserName([FromBody] string userName)
        {
            var userId = int.Parse(
                   User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
            await _applicationUserService.ChangeUserNameAsync(userName, userId);
            return Ok(new
            {
                Message = "User name updated successfully."
            });

        }

        [Authorize(Roles = "User")]
        [HttpPatch]
        [Route("ChangeEmail")]

        public async Task<IActionResult> ChangeEmail([FromBody] string email)
        {
            var userId = int.Parse(
                   User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
            await _applicationUserService.ChangeEmailAsync(email, userId);
            return Ok(new
            {
                Message = "Email updated successfully."
            });
        }

        [Authorize(Roles = "User")]
        [HttpPatch]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] string currentPassword, string newPassword)
        {
            var userId = int.Parse(
                   User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
            await _applicationUserService.ChangePasswordAsync(currentPassword, newPassword, userId);
            return Ok(new
            {
                Message = "Password updated successfully."
            });
        }

        [Authorize(Roles= "User")]
        [HttpPatch]
        [Route("ChangeFirstName")]
        public async Task<IActionResult> ChangeFirstName([FromBody] string firstName)
        {
            var userId = int.Parse(
                   User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
            await _applicationUserService.ChangeFirstNameAsync(firstName, userId);
            return Ok(new
            {
                Message = "First name updated successfully."
            });
        }

        [Authorize(Roles = "User")]
        [HttpPatch]
        [Route("ChangeLastName")]
        public async Task<IActionResult> ChangeLastName([FromBody] string lastName)
        {
            var userId = int.Parse(
                   User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
            await _applicationUserService.ChangeLastNameAsync(lastName, userId);
            return Ok(new
            {
                Message = "Last name updated successfully."
            });
        }

        [Authorize(Roles ="User")]
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync()
        {
            var userId = int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
 );
            await _applicationUserService.DeleteUserAsync( userId);
            return Ok(new
            {
                Message = "User deleted successfully"
            });
        }
    }
}