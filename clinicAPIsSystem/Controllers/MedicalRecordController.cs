using clinicAPIsSystem.DTOs.MedicalRecordDTOs;
using clinicAPIsSystem.IService;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(
            IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord(
            [FromBody] CreateMedicalRecordDto medicalRecord)
        {
            var createdMedicalRecord =
                await _medicalRecordService.CreateMedicalRecordAsync(
                    medicalRecord);

            return CreatedAtAction(
                nameof(GetMedicalRecord),
                new { id = createdMedicalRecord.Id },
                createdMedicalRecord);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            var medicalRecords =
                await _medicalRecordService.GetAllMedicalRecordsAsync();

            return Ok(medicalRecords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecord(int id)
        {
            var medicalRecord =
                await _medicalRecordService.GetMedicalRecord(id);

            return Ok(medicalRecord);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetMedicalRecordByPatientId(
            int patientId)
        {
            var medicalRecord =
                await _medicalRecordService
                    .GetMedicalByPatientIdRecord(patientId);

            return Ok(medicalRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecord(
            int id,
            [FromBody] UpdateMedicalRecordDto medicalRecord)
        {
            var updatedMedicalRecord =
                await _medicalRecordService.UpdateMedicalRecordAsync(
                    medicalRecord,
                    id);

            return Ok(updatedMedicalRecord);
        }
    }
}