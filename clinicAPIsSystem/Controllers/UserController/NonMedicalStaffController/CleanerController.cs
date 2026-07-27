using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.CleanerDTOs;
using clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace clinicAPIsSystem.Controllers.UserController.NonMedicalStaffController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleanerController : ControllerBase
    {
        private readonly ICleanerService _cleanerService; 
        public CleanerController (ICleanerService cleanerService)
        {
            _cleanerService = cleanerService;
        }

        [Authorize(Roles =nameof(Roles.Admin))]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCleanerAsync(CreateCleanerDto dto)
        {
            await _cleanerService.CreateCleanerAsync(dto);
            return NoContent();
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Accountant)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetCleanerByIdAsync(int id) 
        {
          var cleaner =  await _cleanerService.GetCleanerByIdAsync(id);

            return Ok(cleaner);
            
        }
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Accountant)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get/{CleaningArea:string}")]
        public async Task<IActionResult> GetCleanerByCleaningAreasAsync(string cleaningArea)
        {
            var user = await _cleanerService.GetCleanerByCleaningAreasAsync(cleaningArea);
            return Ok(user);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("Update/{id:int}")]

        public async Task<IActionResult> UpdateCleanerAsync(int id , [FromBody] UpdateCleanerDto dto)
        {
            await _cleanerService.UpdateCleanerAsync(id, dto);
            return NoContent(); 
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteCleanerAsync(int id)
        {
            await _cleanerService.DeleteCleanerAsync(id);
            return NoContent(); 
        }
             




    }
}
