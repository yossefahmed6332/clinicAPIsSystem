using clinicAPIsSystem.ClinicDTOs.UserDTOs.PatientDTOs;
using clinicAPIsSystem.Interfaces.IUserService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace clinicAPIsSystem.Services.UserService
{
    public class PatientService:IPatientService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task CreatePatientAsync(CreatePatientDto dto)
        {
            // Check Username
            var userByUsername = await _userManager.FindByNameAsync(dto.UserName);

            if (userByUsername != null)
                throw new InvalidOperationException("Username already exists.");

            // Check Email
            var userByEmail = await _userManager.FindByEmailAsync(dto.Email);

            if (userByEmail != null)
                throw new InvalidOperationException("Email already exists.");

            // Check Phone Number
            var userByPhone = await _userManager.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == dto.PhoneNumber);

            if (userByPhone != null)
                throw new InvalidOperationException("Phone number already exists.");

            // Create Patient
            var patient = new Patient
            {
                //user properties
                FirstName = dto.FirstName,
                LastName= dto.LastName,
                UserName= dto.UserName,
                Email=dto.Email,
                PhoneNumber=dto.PhoneNumber
                //patient properties <in future we can add more properties specific to patient>


            };

            // Create Identity User
            var result = await _userManager.CreateAsync(patient, dto.Password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join(Environment.NewLine,
                        result.Errors.Select(e => e.Description)));
            }

            // Add Patient Role
            await _userManager.AddToRoleAsync(patient, Roles.Patient.ToString());
            await _userManager.AddToRoleAsync(patient, Roles.User.ToString());

        }
    }
}
