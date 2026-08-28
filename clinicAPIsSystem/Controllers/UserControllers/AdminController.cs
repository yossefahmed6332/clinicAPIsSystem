using clinicAPIsSystem.DTOs.UserDTOs.AdminDTO;
using clinicAPIsSystem.IServices.IUserServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateAdmin(
            [FromBody] CreateAdminDto admin
            )
        {
            var createdAdmin =
                await _adminService.CreateAdminAsync(admin  );

            return Ok(createdAdmin);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();

            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var admin = await _adminService.GetAdminAsync(id);

            return Ok(admin);
        }

        // Update current logged-in admin
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyAccount(
            [FromBody] UpdateAdminDto admin)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null)
                return Unauthorized();

            if (!int.TryParse(idClaim.Value, out int id))
                return Unauthorized();

            var updatedAdmin =
                await _adminService.UpdateAdminAsync(admin, id);

            return Ok(updatedAdmin);
        }

        // Update specific admin - intended for Admin
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(
            int id,
            [FromBody] UpdateAdminDto admin)
        {
            var updatedAdmin =
                await _adminService.UpdateAdminAsync(admin, id);

            return Ok(updatedAdmin);
        }
    }
}