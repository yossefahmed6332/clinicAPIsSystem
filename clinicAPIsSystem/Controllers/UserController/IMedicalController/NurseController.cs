using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clinicAPIsSystem.Interfaces.IUserService.IMedicalStaffService;

using clinicAPIsSystem.Models;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.NurseDTOs;
namespace clinicAPIsSystem.Controllers.UserController.IMedicalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseServices _nurseService;
        public NurseController (INurseServices nurseService)
        {
            _nurseService = nurseService; 
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateNurse([FromBody] CreateNurseDto nurseDto)
        {
            await _nurseService.CreateNurseAsync(nurseDto);
            return NoContent();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut]
        public async Task<IActionResult> UpdateNurse(int id, [FromBody] UpdateNurseDto nurseDto)
        {
            await _nurseService.UpdateNurseAsync(id, nurseDto);
            return NoContent();
        }


    }
}
