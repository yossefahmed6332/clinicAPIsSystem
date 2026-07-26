using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.AccountantDTOs;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.MedicalStaff;
using clinicAPIsSystem.Models.User.NonMedicalStaff;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace clinicAPIsSystem.Services.UserService.NonMedicalStaffService
{
    public class AccountantService : IAccountantService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClinicDbContext _clinicDbContext;
        public AccountantService(UserManager<ApplicationUser> userManager, ClinicDbContext clinicDbContext)
        {
            _userManager = userManager;
            _clinicDbContext = clinicDbContext;
        }


        public async Task CreateAccountantAsync(CreateAccountantDto dto)
        {

            // Check if phone number already exists
            if (await _userManager.Users.AnyAsync(u => u.PhoneNumber == dto.PhoneNumber))
                throw new Exception("Phone number already exists.");

            // Check if email already exists
            if (await _userManager.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email already exists.");

            // Check if username already exists
            if (await _userManager.Users.AnyAsync(u => u.UserName == dto.UserName))
                throw new Exception("Username already exists.");

            // Create Accountant entity
            var Accountant = new Accountant
            {
                // ApplicationUser
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,

                // Employee
                SalaryPerHour = dto.SalaryPerHour,
                HoursWorked = dto.HoursWorked,
                ShiftStart = dto.ShiftStart,
                ShiftEnd = dto.ShiftEnd,

                // MedicalStaff
                YearsOfExperience = dto.YearsOfExperience,
                LicenseNumber = dto.LicenseNumber,

            };

            // Create user
            var result = await _userManager.CreateAsync(Accountant, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine,
                    result.Errors.Select(e => e.Description)));
            }

            // Add roles
            var AccountantRoleResult = await _userManager.AddToRoleAsync(Accountant, "Accountant");
            var userRoleResult = await _userManager.AddToRoleAsync(Accountant, "User");

            if (!AccountantRoleResult.Succeeded || !userRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign roles.");
            }
        }


        public async Task<AccountantDto> GetAccountantByIdAsync(int accountantId)
        {
            var accountant = await _clinicDbContext.TAccountants
                .Where(a => a.Id == accountantId)
                .Select(a => new AccountantDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    UserName = a.UserName!,
                    Email = a.Email!,
                    PhoneNumber = a.PhoneNumber!,
                    Gender = a.Gender,
                    SalaryPerHour = a.SalaryPerHour,
                    HoursWorked = a.HoursWorked,
                    ShiftStart = a.ShiftStart,
                    ShiftEnd = a.ShiftEnd,
                    YearsOfExperience = a.YearsOfExperience,
                    LicenseNumber = a.LicenseNumber
                })
                .FirstOrDefaultAsync();
            if (accountant == null)
            {
                throw new Exception("Accountant not found.");
            }
            return accountant;



        }

        public async Task<AccountantDto> GetAccountantByLicenseAsync(string licenseNumber   )
        {
            var accountant = await _clinicDbContext.TAccountants
                .Where(a => a.LicenseNumber == licenseNumber)
                .Select(a => new AccountantDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    UserName = a.UserName!,
                    Email = a.Email!,
                    PhoneNumber = a.PhoneNumber!,
                    Gender = a.Gender,
                    SalaryPerHour = a.SalaryPerHour,
                    HoursWorked = a.HoursWorked,
                    ShiftStart = a.ShiftStart,
                    ShiftEnd = a.ShiftEnd,
                    YearsOfExperience = a.YearsOfExperience,
                    LicenseNumber = a.LicenseNumber,
                }).FirstOrDefaultAsync();
            if (accountant == null)
            {
                throw new Exception("Accountant not found.");
            }

            return accountant;





        }

    }
}