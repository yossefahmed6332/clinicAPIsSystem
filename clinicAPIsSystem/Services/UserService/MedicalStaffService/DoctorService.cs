using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces.IUserService.IMedicalStaffService;
using clinicAPIsSystem.Models.User.MedicalStaff;
using clinicAPIsSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
namespace clinicAPIsSystem.Services.UserService.MedicalStaffService
{
    public class DoctorService : IDoctorService
    {
        private readonly UserManager<Doctor> _userManager;
        private readonly ClinicDbContext _context;
        private readonly ISpecializationService _specializationService;
        public DoctorService(UserManager<Doctor> userManager, ISpecializationService specializationService, ClinicDbContext context
            )
        {
            _userManager = userManager;
            _specializationService = specializationService;
            _context = context;
        }
        //create doctor method 
        public async Task CreateDoctorAsync(CreateDoctorDto doctorDto)
        {
            // Check if phone number already exists
            if (await _userManager.Users.AnyAsync(u => u.PhoneNumber == doctorDto.PhoneNumber))
                throw new Exception("Phone number already exists.");

            // Check if email already exists
            if (await _userManager.Users.AnyAsync(u => u.Email == doctorDto.Email))
                throw new Exception("Email already exists.");

            // Check if username already exists
            if (await _userManager.Users.AnyAsync(u => u.UserName == doctorDto.UserName))
                throw new Exception("Username already exists.");

            // Create doctor entity
            var doctor = new Doctor
            {
                // ApplicationUser
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                UserName = doctorDto.UserName,
                Email = doctorDto.Email,
                PhoneNumber = doctorDto.PhoneNumber,
                Gender = doctorDto.Gender,

                // Employee
                SalaryPerHour = doctorDto.SalaryPerHour,
                HoursWorked = doctorDto.HoursWorked,
                ShiftStart = doctorDto.ShiftStart,
                ShiftEnd = doctorDto.ShiftEnd,

                // MedicalStaff
                YearsOfExperience = doctorDto.YearsOfExperience,
                LicenseNumber = doctorDto.LicenseNumber,
                QualificationId = doctorDto.QualificationId,

                // Doctor
                SpecializationId = doctorDto.SpecializationId
            };

            // Create user
            var result = await _userManager.CreateAsync(doctor, doctorDto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine,
                    result.Errors.Select(e => e.Description)));
            }

            // Add roles
            var doctorRoleResult = await _userManager.AddToRoleAsync(doctor, "Doctor");
            var userRoleResult = await _userManager.AddToRoleAsync(doctor, "User");

            if (!doctorRoleResult.Succeeded || !userRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign roles.");
            }
        }


        //method for getting doctors from specialization 
        public async Task<IEnumerable<DoctorDto>> GetDoctorBySpecializationAsync(string specialization)
        {
            var specializationExists = await _context.TSpecializations.
                AnyAsync(s => s.Name == specialization);

            if (!specializationExists)
            {
                throw new Exception("Specialization not found , add new specialization with name and description");
            }


            var doctors = await _context.TDoctors
                .Where(a => a.Specialization.Name == specialization)
                .Select(doctorDto => new DoctorDto
                {
                    // ApplicationUser
                    FirstName = doctorDto.FirstName,
                    LastName = doctorDto.LastName,
                    UserName = doctorDto.UserName,
                    Email = doctorDto.Email,
                    PhoneNumber = doctorDto.PhoneNumber,
                    Gender = doctorDto.Gender,

                    // Employee
                    SalaryPerHour = doctorDto.SalaryPerHour,
                    HoursWorked = doctorDto.HoursWorked,
                    ShiftStart = doctorDto.ShiftStart,
                    ShiftEnd = doctorDto.ShiftEnd,

                    // MedicalStaff
                    YearsOfExperience = doctorDto.YearsOfExperience,
                    LicenseNumber = doctorDto.LicenseNumber,
                    QualificationId = doctorDto.QualificationId,

                    // Doctor
                    SpecializationName = doctorDto.Specialization.Name,
                })
                .ToListAsync();

            if (doctors.Count == 0)
            {
                throw new Exception("Not found");
            }

            return doctors;
        }

        public async Task UpdateDoctorSpecializationAsync(int doctorId, string specializationName)
        {
            var specialization = await _context.TSpecializations.
                FirstOrDefaultAsync(s => s.Name == specializationName);

            if (specialization == null)
            {
                throw new Exception("Specialization not found , add new specialization with name and description");
            }

            var doctor = await _context.TDoctors.FindAsync(doctorId);

            if (doctor == null)
            {
                throw new Exception("Doctor Not found");
            }
            doctor.SpecializationId = specialization.Id;
            await _context.SaveChangesAsync();

        }

        public async Task UpdateYearsOfExperienceAsync(int doctorId, int yearsOfExperience)
        {
            var doctor = await _context.TDoctors
                .FindAsync(doctorId); 
            if (doctor ==null)
            {
                throw new Exception("doctor Not found");
            }

            doctor.YearsOfExperience= yearsOfExperience; 
            await _context.SaveChangesAsync(); 


        }
        public async Task UpdateLicenseNumberAsync(int doctorId, string licenseNumber)
        {
            var doctor = await _context.TDoctors
                .FindAsync(doctorId);
            if (doctor == null)
            {
                throw new Exception("doctor Not found");
            }

            doctor.LicenseNumber= licenseNumber;
            await _context.SaveChangesAsync();
        }
    }
}
