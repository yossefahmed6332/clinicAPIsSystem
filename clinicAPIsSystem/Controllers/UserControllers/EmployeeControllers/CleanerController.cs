using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.CleanerDTO;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleanerController : ControllerBase
    {
        private readonly ICleanerService _cleanerService;

        public CleanerController(ICleanerService cleanerService)
        {
            _cleanerService = cleanerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateCleaner(
            [FromBody] CreateCleanerDto createCleanerDto,
            string password)
        {
            var cleaner = await _cleanerService.CreateCleanerAsync(
                createCleanerDto,
                password);

            return Ok(cleaner);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCleaners()
        {
            var cleaners = await _cleanerService.GetAllCleanersAsync();

            return Ok(cleaners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCleaner(int id)
        {
            var cleaner = await _cleanerService.GetCleanerAsync(id);

            return Ok(cleaner);
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyAccount(
            [FromBody] UpdateCleanerDto updateCleanerDto)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null)
                return Unauthorized();

            if (!int.TryParse(idClaim.Value, out int id))
                return Unauthorized();

            var updatedCleaner =
                await _cleanerService.UpdateCleanerAsync(
                    updateCleanerDto,
                    id);

            return Ok(updatedCleaner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCleaner(
            int id,
            [FromBody] UpdateCleanerDto updateCleanerDto)
        {
            var updatedCleaner =
                await _cleanerService.UpdateCleanerAsync(
                    updateCleanerDto,
                    id);

            return Ok(updatedCleaner);
        }
    }
}