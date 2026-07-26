using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.NurseDTOs;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces.IUserService.IMedicalStaffService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.MedicalStaff;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace clinicAPIsSystem.Services.UserService.MedicalStaffService
{
    public class NurseService:INurseServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClinicDbContext _context; 
        public NurseService(UserManager<ApplicationUser> userManager,ClinicDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task CreateNurseAsync(CreateNurseDto nurseDto)
        {
            // Check if phone number already exists
            if (await _userManager.Users.AnyAsync(u => u.PhoneNumber == nurseDto.PhoneNumber))
                throw new Exception("Phone number already exists.");

            // Check if email already exists
            if (await _userManager.Users.AnyAsync(u => u.Email == nurseDto.Email))
                throw new Exception("Email already exists.");

            // Check if username already exists
            if (await _userManager.Users.AnyAsync(u => u.UserName == nurseDto.UserName))
                throw new Exception("Username already exists.");

            //create new nurse 
            var nurse = new Doctor
            {
                // ApplicationUser
                FirstName = nurseDto.FirstName,
                LastName = nurseDto.LastName,
                UserName = nurseDto.UserName,
                Email = nurseDto.Email,
                PhoneNumber = nurseDto.PhoneNumber,
                Gender = nurseDto.Gender,

                // Employee
                SalaryPerHour = nurseDto.SalaryPerHour,
                HoursWorked = nurseDto.HoursWorked,
                ShiftStart = nurseDto.ShiftStart,
                ShiftEnd = nurseDto.ShiftEnd,

                // MedicalStaff
                YearsOfExperience = nurseDto.YearsOfExperience,
                LicenseNumber = nurseDto.LicenseNumber,
                QualificationId = nurseDto.QualificationId,
            };
            var result = await _userManager.CreateAsync(nurse,nurseDto.Password);
            //Add Roles
            var doctorRoleResult = await _userManager.AddToRoleAsync(nurse, "Nurse");
            var userRoleResult = await _userManager.AddToRoleAsync(nurse, "User");

            if (!doctorRoleResult.Succeeded || !userRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign roles.");
            }
        }


    public async Task UpdateYearsOfExperienceAsync(int nurseId ,int yearsOfExperience)
        {
            var nurse= await _context.TNurses.FindAsync(nurseId);

            if (nurse == null)
            {
                throw new Exception($"Nurse with ID{nurseId} doesn't exist ");

            }
            nurse.YearsOfExperience= yearsOfExperience;
            await _context.SaveChangesAsync();

        }


    public async Task UpdateLicenseNumberAsync(int nurseId , string licenseNumber)
        {
            var nurse = await _context.TNurses.FindAsync(nurseId);

            if (nurse == null)
            {
                throw new Exception($"Nurse with ID{nurseId} doesn't exist ");

            }

            nurse.LicenseNumber= licenseNumber;
            await _context.SaveChangesAsync();
        }
    }
}
