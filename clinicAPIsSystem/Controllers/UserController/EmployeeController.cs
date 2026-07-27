using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clinicAPIsSystem.Interfaces.IUserService;
using Microsoft.AspNetCore.Authorization;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;

namespace clinicAPIsSystem.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("receptionists")]
        public async Task<IActionResult> CreateReceptionist([FromBody] CreateEmployeeDto receptionistDto)
        {
            await _employeeService.CreateReceptionistAsync(receptionistDto);
            return Ok();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("admins")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateEmployeeDto adminDto)
        {
            await _employeeService.CreateAdminAsync(adminDto);
            return Ok();
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Accountant)}")]
        [HttpGet("by-salary/{salary:decimal}")]
        public async Task<IActionResult> GetEmployeesBySalary(decimal salary)
        {
            var employees = await _employeeService.GetEmployeesBySalaryAsync(salary);
            return Ok(employees);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Accountant)}")]
        [HttpGet("by-hours-worked/{hoursWorked:int}")]
        public async Task<IActionResult> GetEmployeesByHoursWorked(int hoursWorked)
        {
            var employees = await _employeeService.GetEmployeesByHoursWorkedAsync(hoursWorked);
            return Ok(employees);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Accountant)}")]
        [HttpGet("by-shift-start/{shiftStart}")]
        public async Task<IActionResult> GetEmployeesByShiftStart(TimeOnly shiftStart)
        {
            var employees = await _employeeService.GetEmployeesByShiftStartAsync(shiftStart);
            return Ok(employees);
        }
    }
}