using clinicAPIsSystem.ClinicDTOs.QualificationDTOs;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;

        public QualificationController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }

        #region Create

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        public async Task<IActionResult> AddQualification([FromBody] CreateQualificationDto dto)
        {
            await _qualificationService.AddQualificationAsync(dto);
            return Ok();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("{qualificationId:int}/medical-staff/{medicalStaffId:int}")]
        public async Task<IActionResult> AssignQualificationToMedicalStaff(
            int qualificationId,
            int medicalStaffId)
        {
            await _qualificationService.AssignQualificationToMedicalStaffAsync(
                qualificationId,
                medicalStaffId);

            return Ok();
        }

        #endregion

        #region Read

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllQualifications()
        {
            var qualifications = await _qualificationService.GetAllQualificationsAsync();
            return Ok(qualifications);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetQualificationById(int id)
        {
            var qualification = await _qualificationService.GetQualificationByIdAsync(id);
            return Ok(qualification);
        }

        [Authorize]
        [HttpGet("{qualificationId:int}/medical-staff")]
        public async Task<IActionResult> GetMedicalStaffsByQualificationId(int qualificationId)
        {
            var medicalStaffs = await _qualificationService
                .GetMedicalStaffsByQualificationIdAsync(qualificationId);

            return Ok(medicalStaffs);
        }

        #endregion

        #region Update

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{qualificationId:int}")]
        public async Task<IActionResult> UpdateQualification(
            int qualificationId,
            [FromBody] UpdateQualificationDto dto)
        {
            await _qualificationService.UpdateQualificationAsync(qualificationId, dto);
            return Ok();
        }

        #endregion

        #region Delete

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteQualification(int id)
        {
            await _qualificationService.DeleteQualificationAsync(id);
            return Ok();
        }

        #endregion
    }
}