using clinicAPIsSystem.IServices.IUserServices;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            return Ok(user);
        }

        [HttpGet("exists/phone/{phoneNumber}")]
        public async Task<IActionResult> PhoneNumberExists(string phoneNumber)
        {
            var result = await _userService.PhoneNumberExistsAsync(phoneNumber);
            return Ok(result);
        }

        [HttpGet("exists/email/{email}")]
        public async Task<IActionResult> EmailExists(string email)
        {
            var result = await _userService.EmailExistsAsync(email);
            return Ok(result);
        }

        [HttpGet("exists/username/{username}")]
        public async Task<IActionResult> UsernameExists(string username)
        {
            var result = await _userService.UsernameExistsAsync(username);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}