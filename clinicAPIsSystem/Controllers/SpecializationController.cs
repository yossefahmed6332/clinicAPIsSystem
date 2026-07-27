using clinicAPIsSystem.ClinicDTOs.SpecializationDTOs;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        #region Create

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        public async Task<IActionResult> AddSpecialization([FromBody] CreateSpecializationDto dto)
        {
            await _specializationService.AddSpecializationAsync(dto);
            return Ok();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("{specializationId:int}/doctors/{doctorId:int}")]
        public async Task<IActionResult> AssignSpecializationToDoctor(
            int specializationId,
            int doctorId)
        {
            await _specializationService.AssignSpecializationToDoctorAsync(
                specializationId,
                doctorId);

            return Ok();
        }

        #endregion

        #region Read

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllSpecializations()
        {
            var specializations = await _specializationService.GetAllSpecializationsAsync();
            return Ok(specializations);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpecializationById(int id)
        {
            var specialization = await _specializationService.GetSpecializationByIdAsync(id);
            return Ok(specialization);
        }

        [Authorize]
        [HttpGet("{specializationId:int}/doctors")]
        public async Task<IActionResult> GetDoctorsBySpecializationId(int specializationId)
        {
            var doctors = await _specializationService
                .GetDoctorsBySpecializationIdAsync(specializationId);

            return Ok(doctors);
        }

        #endregion

        #region Update

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSpecialization(
            int id,
            [FromBody] UpdateSpecializationDto dto)
        {
            await _specializationService.UpdateSpecializationAsync(id, dto);
            return Ok();
        }

        #endregion

        #region Delete

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            await _specializationService.DeleteSpecializationAsync(id);
            return Ok();
        }

        #endregion
    }
}