using clinicAPIsSystem.ClinicDTOs.AuthDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.PatientDTOs;
using clinicAPIsSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices; 
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authServices.LoginAsync(dto); 
            
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreatePatientDto user)
        {
            await _authServices.RegisterAsUserAsync(user);
            return Ok("User registered successfully");
        }

    }
}
