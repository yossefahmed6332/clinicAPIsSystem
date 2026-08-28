using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ManagerDTO;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.NonMedicalStaffServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateManager(
            [FromBody] CreateManagerDto createManagerDto
            )
        {
            var manager = await _managerService.CreateManagerAsync(
                createManagerDto
                );

            return Ok(manager);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllManagers()
        {
            var managers = await _managerService.GetAllManagersAsync();

            return Ok(managers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManager(int id)
        {
            var manager = await _managerService.GetManagerAsync(id);

            return Ok(manager);
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyAccount(
            [FromBody] UpdateManagerDto updateManagerDto)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null)
                return Unauthorized();

            if (!int.TryParse(idClaim.Value, out int id))
                return Unauthorized();

            var updatedManager =
                await _managerService.UpdateManagerAsync(
                    updateManagerDto,
                    id);

            return Ok(updatedManager);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManager(
            int id,
            [FromBody] UpdateManagerDto updateManagerDto)
        {
            var updatedManager =
                await _managerService.UpdateManagerAsync(
                    updateManagerDto,
                    id);

            return Ok(updatedManager);
        }
    }
}