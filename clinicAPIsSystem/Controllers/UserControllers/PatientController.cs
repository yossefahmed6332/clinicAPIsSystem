using clinicAPIsSystem.DTOs.MedicalRecordDTOs;
using clinicAPIsSystem.DTOs.UserDTOs.PatientDTO;
using clinicAPIsSystem.IServices.IUserServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreatePatient(
            [FromBody] CreatePatientDto createPatientDto
            )
        {
            var patient = await _patientService.CreatePatientAsync(
                createPatientDto
                );

            return Ok(patient);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientAsync(id);

            return Ok(patient);
        }

        // Update current logged-in patient
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyAccount(
            [FromBody] UpdatePatientDto updatePatientDto)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null)
                return Unauthorized();

            if (!int.TryParse(idClaim.Value, out int id))
                return Unauthorized();

            var updatedPatient =
                await _patientService.UpdatePatientAsync(
                    updatePatientDto,
                    id);

            return Ok(updatedPatient);
        }

        // Update specific patient - Admin
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(
            int id,
            [FromBody] UpdatePatientDto updatePatientDto)
        {
            var updatedPatient =
                await _patientService.UpdatePatientAsync(
                    updatePatientDto,
                    id);

            return Ok(updatedPatient);
        }
    }
}