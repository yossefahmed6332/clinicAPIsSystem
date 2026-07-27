using clinicAPIsSystem.ClinicDTOs.OperationDtos;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService; 
        public OperationController (IOperationService operationService)
        {
            _operationService = operationService;
        }

        [Authorize(Roles =$"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpPost]
        public async Task<IActionResult> CreateOperationAsync(CreateOperationDto dto)
        {
            await _operationService.AddOperationAsync(dto);
            return NoContent();
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Receptionist)}")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOperationsAsync()
        {
            var operations =await _operationService.GetAllOperationsAsync();
            return Ok(operations);
        }
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Receptionist)}")]
        [HttpGet("by-id/{id:int}")]
        public async Task<IActionResult> GetOperationByIdAsync(int id)
        {
            var operation = await _operationService.GetOperationByIdAsync(id);
            return Ok(operation);

        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Receptionist)}")]
        [HttpGet("by-patint-id/{id}")]

        public async Task<IActionResult> GetByPatientIdAsync(int id)
        {
            var operation = await _operationService.GetOperationsByPatientIdAsync(id);
            return Ok(operation);
        }
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Receptionist)}")]
        [HttpGet("by-receptionist-id/{id}")]
        public async Task<IActionResult> GetOperationsByReceptionistIdAsync(int id)
        {
            var operation = await _operationService.GetOperationsByReceptionistIdAsync(id);
            return Ok(operation);
        }
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)},{nameof(Roles.Receptionist)}")]
        [HttpGet("by-appointment-id/{id}")]

        public async Task<IActionResult> GetOperationsByAppointmentIdAsync(int id)
        {
            var operations = await _operationService.GetOperationsByAppointmentIdAsync(id); 
            return Ok(operations);
        }



    }
}
