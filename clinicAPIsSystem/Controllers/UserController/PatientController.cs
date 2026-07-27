using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.PatientDTOs;
using clinicAPIsSystem.Interfaces.IUserService;
using Microsoft.AspNetCore.Authorization;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.Controllers.UserController
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
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatientAsync([FromBody] CreatePatientDto dto)
        {
            await _patientService.CreatePatientAsync(dto);
            return Ok();
        }


    }
}
