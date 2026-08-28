using clinicAPIsSystem.DTOs.PrescriptionDTOs;
using clinicAPIsSystem.IService;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(
            IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription(
            [FromBody] CreatePrescriptionDto createPrescriptionDto)
        {
            var createdPrescription =
                await _prescriptionService.CreatePrescriptionAsync(
                    createPrescriptionDto);

            return CreatedAtAction(
                nameof(GetPrescription),
                new { id = createdPrescription.Id },
                createdPrescription);
        }
            
        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions =
                await _prescriptionService.GetAllPrescriptionsAsync();

            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescription =
                await _prescriptionService.GetPrescriptionAsync(id);

            return Ok(prescription);
        }

        [HttpGet("medical-record/{medicalRecordId}")]
        public async Task<IActionResult> GetPrescriptionsByMedicalRecordId(
            int medicalRecordId)
        {
            var prescriptions =
                await _prescriptionService
                    .GetPrescriptionsByMedicalRecordIdAsync(medicalRecordId);

            return Ok(prescriptions);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetPrescriptionsByDoctorId(
            int doctorId)
        {
            var prescriptions =
                await _prescriptionService
                    .GetPrescriptionsByDoctorIdAsync(doctorId);

            return Ok(prescriptions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(
            int id,
            [FromBody] UpdatePrescriptionDto updatePrescriptionDto)
        {
            var updatedPrescription =
                await _prescriptionService.UpdatePrescriptionAsync(
                    updatePrescriptionDto,
                    id);

            return Ok(updatedPrescription);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            await _prescriptionService.DeletePrescriptionAsync(id);

            return NoContent();
        }
    }
}