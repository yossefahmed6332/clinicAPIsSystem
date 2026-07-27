using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clinicAPIsSystem.ClinicDTOs.MedicalDTOs;
using clinicAPIsSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalController : ControllerBase
    {
        private readonly IMedicalService _medicalService;
        public MedicalController(IMedicalService medicalService)
        {
            _medicalService = medicalService;
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)}, {nameof(Roles.Doctor)}")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddMedicalAsync([FromBody] CreateMedicalDto medical)
        {
            await _medicalService.AddMedicalAsync(medical);
            return NoContent();
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)}, {nameof(Roles.Doctor)}, {nameof(Roles.Nurse)}, {nameof(Roles.Receptionist)}")]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllMedicalsAsync()
        {
            var medicals = await _medicalService.GetAllMedicalsAsync();
            return Ok(medicals);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)}, {nameof(Roles.Doctor)}, {nameof(Roles.Nurse)}, {nameof(Roles.Receptionist)}")]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetMedicalByIdAsync(int id)
        {
            var medical = await _medicalService.GetMedicalByIdAsync(id);
            
            return Ok(medical);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)}, {nameof(Roles.Doctor)}")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateMedicalAsync([FromBody] UpdateMedicalDto medical, int id)
        {
            var updatedMedical = await _medicalService.UpdateMedicalAsync(medical, id);
            return Ok(updatedMedical);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMedicalById(int id)
        {
            await _medicalService.DeleteMedicalAsync(id);
            return NoContent(); 
        }
    }
}
