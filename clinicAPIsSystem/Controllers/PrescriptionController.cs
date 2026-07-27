using clinicAPIsSystem.ClinicDTOs.PrescriptionDTOs;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        #region Create

        [Authorize(Roles = nameof(Roles.Doctor))]
        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] CreatePresciptionDto dto)
        {
            await _prescriptionService.AddPrescriptionAsync(dto);
            return Ok();
        }

        [Authorize(Roles = nameof(Roles.Doctor))]
        [HttpPost("{prescriptionId:int}/medications/{medicalId:int}")]
        public async Task<IActionResult> AddMedicalToPrescription(int prescriptionId, int medicalId)
        {
            await _prescriptionService.AddMedicalToPrescriptionAsync(prescriptionId, medicalId);
            return Ok();
        }

        #endregion

        #region Read

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Doctor)}")]
        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionService.GetAllPrescriptionsAsync();
            return Ok(prescriptions);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            return Ok(prescription);
        }

        [Authorize]
        [HttpGet("patient/{patientId:int}")]
        public async Task<IActionResult> GetPrescriptionsByPatientId(int patientId)
        {
            var prescriptions = await _prescriptionService.GetPrescriptionsByPatientIdAsync(patientId);
            return Ok(prescriptions);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Doctor)}")]
        [HttpGet("doctor/{doctorId:int}")]
        public async Task<IActionResult> GetPrescriptionsByDoctorId(int doctorId)
        {
            var prescriptions = await _prescriptionService.GetPrescriptionsByDoctorIdAsync(doctorId);
            return Ok(prescriptions);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Doctor)}")]
        [HttpGet("medical/{medicalId:int}")]
        public async Task<IActionResult> GetPrescriptionsByMedicalId(int medicalId)
        {
            var prescriptions = await _prescriptionService.GetPrescriptionsByMedicalIdAsync(medicalId);
            return Ok(prescriptions);
        }

        #endregion

        #region Update

        [Authorize(Roles = nameof(Roles.Doctor))]
        [HttpPut("{prescriptionId:int}")]
        public async Task<IActionResult> UpdatePrescription(
            int prescriptionId,
            [FromBody] PrescriptionDto dto)
        {
            await _prescriptionService.UpdatePrescriptionAsync(prescriptionId, dto);
            return Ok();
        }

        #endregion

        #region Delete

        [Authorize(Roles = nameof(Roles.Doctor))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            await _prescriptionService.DeletePrescriptionAsync(id);
            return Ok();
        }

        [Authorize(Roles = nameof(Roles.Doctor))]
        [HttpDelete("{prescriptionId:int}/medications/{medicalId:int}")]
        public async Task<IActionResult> RemoveMedicalFromPrescription(int prescriptionId, int medicalId)
        {
            await _prescriptionService.RemoveMedicalFromPrescriptionAsync(prescriptionId, medicalId);
            return Ok();
        }

        #endregion
    }
}