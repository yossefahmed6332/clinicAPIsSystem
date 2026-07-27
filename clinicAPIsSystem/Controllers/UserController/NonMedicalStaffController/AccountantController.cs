using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService;
using Microsoft.AspNetCore.Authorization;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.AccountantDTOs;
using Microsoft.Identity.Client;

namespace clinicAPIsSystem.Controllers.UserController.NonMedicalStaffController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountantController : ControllerBase
    {
        private readonly IAccountantService _accountantService;
        public AccountantController (IAccountantService accountantService)
        {
            _accountantService = accountantService;
        }

        [Authorize(Roles =nameof(Roles.Admin))]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAccountantAsync([FromBody] CreateAccountantDto dto)
        {
            await _accountantService.CreateAccountantAsync(dto); 
            return NoContent();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("get-by-license")]
        public async Task<IActionResult> GetAccountByLicenseAsync(string licenseId)
        {
            var accountant = await _accountantService.GetAccountantByLicenseAsync(licenseId);
            return Ok(accountant);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateAccountantAsync(int id, [FromBody] UpdateAccountantDto accountant)
        {
            await _accountantService.UpdateAccountantAsync(id, accountant);
            return NoContent();
        }



    }
}
