using Microsoft.AspNetCore.Mvc;
using clinicAPIsSystem.Interfaces.IUserService.IMedicalStaffService;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs;
namespace clinicAPIsSystem.Controllers.UserController.IMedicalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto doctorDto)
        {
            await _doctorService.CreateDoctorAsync(doctorDto);
            return Ok();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("by-specialization")]
        public async Task<IActionResult> GetDoctorsBySpecialization([FromRoute] string specialization)
        {
            var doctors = await _doctorService.GetDoctorBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto doctorDto)
        {
            await _doctorService.UpdateDoctorAsync(id, doctorDto);
            return Ok();
        }


    }
}
