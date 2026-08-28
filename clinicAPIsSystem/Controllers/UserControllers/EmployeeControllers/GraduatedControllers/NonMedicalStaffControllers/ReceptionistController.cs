using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ReceptionistDTO;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.NonMedicalStaffServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly IReceptionistService _receptionistService;

        public ReceptionistController(IReceptionistService receptionistService)
        {
            _receptionistService = receptionistService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateReceptionist(
            [FromBody] CreateReceptionistDto createReceptionistDto
            )
        {
            var receptionist =
                await _receptionistService.CreateReceptionistAsync(
                    createReceptionistDto
                    );

            return Ok(receptionist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceptionist(int id)
        {
            var receptionist =
                await _receptionistService.GetReceptionistAsync(id);

            return Ok(receptionist);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllReceptionists()
        {
            var receptionists =
                await _receptionistService.GetAllReceptionistsAsync();

            return Ok(receptionists);
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyAccount(
            [FromBody] UpdateReceptionistDto updateReceptionistDto)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null)
                return Unauthorized();

            if (!int.TryParse(idClaim.Value, out int id))
                return Unauthorized();

            var updatedReceptionist =
                await _receptionistService.UpdateReceptionistAsync(
                    updateReceptionistDto,
                    id);

            return Ok(updatedReceptionist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceptionist(
            int id,
            [FromBody] UpdateReceptionistDto updateReceptionistDto)
        {
            var updatedReceptionist =
                await _receptionistService.UpdateReceptionistAsync(
                    updateReceptionistDto,
                    id);

            return Ok(updatedReceptionist);
        }
    }
}