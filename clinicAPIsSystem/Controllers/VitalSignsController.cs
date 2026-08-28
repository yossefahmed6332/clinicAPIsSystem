using clinicAPIsSystem.DTOs.VitalSignsDTOs;
using clinicAPIsSystem.IService;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalSignsController : ControllerBase
    {
        private readonly IVitalSignsService _vitalSignsService;

        public VitalSignsController(
            IVitalSignsService vitalSignsService)
        {
            _vitalSignsService = vitalSignsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVitalSigns(
            [FromBody] CreateVitalSignsDto createVitalSignsDto)
        {
            var createdVitalSigns =
                await _vitalSignsService.CreateVitalSignsAsync(
                    createVitalSignsDto);

            return CreatedAtAction(
                nameof(GetVitalSigns),
                new { id = createdVitalSigns.Id },
                createdVitalSigns);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVitalSigns()
        {
            var vitalSigns =
                await _vitalSignsService.GetAllVitalSignsAsync();

            return Ok(vitalSigns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVitalSigns(int id)
        {
            var vitalSigns =
                await _vitalSignsService.GetVitalSignsAsync(id);

            return Ok(vitalSigns);
        }

        [HttpGet("medical-record/{medicalRecordId}")]
        public async Task<IActionResult> GetVitalSignsByMedicalRecordId(
            int medicalRecordId)
        {
            var vitalSigns =
                await _vitalSignsService
                    .GetVitalSignsByMedicalRecordIdAsync(medicalRecordId);

            return Ok(vitalSigns);
        }

        [HttpGet("nurse/{nurseId}")]
        public async Task<IActionResult> GetVitalSignsByNurseId(
            int nurseId)
        {
            var vitalSigns =
                await _vitalSignsService
                    .GetVitalSignsByNurseIdAsync(nurseId);

            return Ok(vitalSigns);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVitalSigns(
            int id,
            [FromBody] UpdateVitalSignsDto updateVitalSignsDto)
        {
            var updatedVitalSigns =
                await _vitalSignsService.UpdateVitalSignsAsync(
                    updateVitalSignsDto,
                    id);

            return Ok(updatedVitalSigns);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitalSigns(int id)
        {
            await _vitalSignsService.DeleteVitalSignsAsync(id);

            return NoContent();
        }
    }
}