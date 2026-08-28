using clinicAPIsSystem.DTOs.ExaminationResultDTOs;
using clinicAPIsSystem.IService;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationResultController : ControllerBase
    {
        private readonly IExaminationResultService _examinationResultService;

        public ExaminationResultController(
            IExaminationResultService examinationResultService)
        {
            _examinationResultService = examinationResultService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExaminationResult(
            [FromBody] CreateExaminationResultDto createExaminationResultDto)
        {
            var createdExaminationResult =
                await _examinationResultService.CreateExaminationResultAsync(
                    createExaminationResultDto);

            return CreatedAtAction(
                nameof(GetExaminationResult),
                new { id = createdExaminationResult.Id },
                createdExaminationResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExaminationResults()
        {
            var examinationResults =
                await _examinationResultService.GetAllExaminationResultsAsync();

            return Ok(examinationResults);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExaminationResult(int id)
        {
            var examinationResult =
                await _examinationResultService.GetExaminationResultAsync(id);

            return Ok(examinationResult);
        }

        [HttpGet("nurse/{nurseId}")]
        public async Task<IActionResult> GetExaminationResultsByNurseId(
            int nurseId)
        {
            var examinationResults =
                await _examinationResultService
                    .GetExaminationResultsByNurseIdAsync(nurseId);

            return Ok(examinationResults);
        }

        [HttpGet("medical-record/{medicalRecordId}")]
        public async Task<IActionResult> GetExaminationResultsByMedicalRecordId(
            int medicalRecordId)
        {
            var examinationResults =
                await _examinationResultService
                    .GetExaminationResultsByMedicalRecordIdAsync(medicalRecordId);

            return Ok(examinationResults);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExaminationResult(
            int id,
            [FromBody] UpdateExaminationResultDto updateExaminationResultDto)
        {
            var updatedExaminationResult =
                await _examinationResultService
                    .UpdateExaminationResultAsync(
                        updateExaminationResultDto,
                        id);

            return Ok(updatedExaminationResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExaminationResult(int id)
        {
            await _examinationResultService.DeleteExaminationResultAsync(id);

            return NoContent();
        }
    }
}