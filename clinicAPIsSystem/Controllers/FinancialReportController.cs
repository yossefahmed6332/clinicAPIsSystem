using clinicAPIsSystem.DTOs.FinanialReportDTOs;
using clinicAPIsSystem.IService;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialReportController : ControllerBase
    {
        private readonly IFinancialReportService _financialReportService;

        public FinancialReportController(
            IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinancialReport(
            [FromBody] CreateFinancialReportDto createFinancialReportDto)
        {
            var createdFinancialReport =
                await _financialReportService.CreateFinancialReportAsync(
                    createFinancialReportDto);

            return CreatedAtAction(
                nameof(GetFinancialReport),
                new { id = createdFinancialReport.Id },
                createdFinancialReport);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFinancialReports()
        {
            var financialReports =
                await _financialReportService.GetAllFinancialReportsAsync();

            return Ok(financialReports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinancialReport(int id)
        {
            var financialReport =
                await _financialReportService.GetFinancialReportAsync(id);

            return Ok(financialReport);
        }

        [HttpGet("range")]
        public async Task<IActionResult> GetFinancialReportsByRange(
            [FromQuery] decimal min,
            [FromQuery] decimal max,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var financialReports =
                await _financialReportService.GetFinancialReportsByRangeAsync(
                    min,
                    max,
                    startDate,
                    endDate);

            return Ok(financialReports);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetFinancialReportsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var financialReports =
                await _financialReportService.GetFinancialReportsByDateRangeAsync(
                    startDate,
                    endDate);

            return Ok(financialReports);
        }
    }
}