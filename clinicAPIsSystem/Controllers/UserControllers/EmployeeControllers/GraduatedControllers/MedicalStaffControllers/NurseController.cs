using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.Nurse;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.IMedicalStaffServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseService _nurseService;

        public NurseController(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateNurse(
            [FromBody] CreateNurseDto createNurseDto
            )
        {
            var nurse =
                await _nurseService.CreateNurseAsync(
                    createNurseDto
                    );

            return Ok(nurse);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllNurses()
        {
            var nurses =
                await _nurseService.GetAllNursesAsync();

            return Ok(nurses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNurse(int id)
        {
            var nurse =
                await _nurseService.GetNurseAsync(id);

            return Ok(nurse);
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyAccount(
            [FromBody] UpdateNurseDto updateNurseDto)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null)
                return Unauthorized();

            if (!int.TryParse(idClaim.Value, out int id))
                return Unauthorized();

            var updatedNurse =
                await _nurseService.UpdateNurseAsync(
                    updateNurseDto,
                    id);

            return Ok(updatedNurse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNurse(
            int id,
            [FromBody] UpdateNurseDto updateNurseDto)
        {
            var updatedNurse =
                await _nurseService.UpdateNurseAsync(
                    updateNurseDto,
                    id);

            return Ok(updatedNurse);
        }
    }
}