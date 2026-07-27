using clinicAPIsSystem.ClinicDTOs.AuthDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.PatientDTOs;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Interfaces
{
    public interface IAuthServices
    {
        public Task<string> LoginAsync(LoginDto dto);
        public Task<string> GenerateJwtTokenAsync(ApplicationUser user);
        public Task RegisterAsUserAsync(CreatePatientDto user);

    }
}
