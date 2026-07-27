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
            var doctorRoleResult = await _userManager.AddToRoleAsync(nurse, Roles.Nurse.ToString());

            if (!doctorRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign roles.");
            }
        }

        public async Task UpdateNurseAsync (int id , UpdateNurseDto nurseDto)
        {
            var nurse = await _context.TNurses.FindAsync(id);
            if (nurse == null)
            {
                throw new Exception("Nurse not found.");
            }
            // Update properties
            nurse.FirstName = nurseDto.FirstName;
            nurse.LastName = nurseDto.LastName;
            nurse.PhoneNumber = nurseDto.PhoneNumber;
            nurse.Gender = nurseDto.Gender;
            nurse.Email = nurseDto.Email;
            nurse.UserName = nurseDto.UserName;
            nurse.ShiftStart = nurseDto.ShiftStart;
            nurse.ShiftEnd = nurseDto.ShiftEnd;
            nurse.SalaryPerHour = nurseDto.SalaryPerHour;
            nurse.HoursWorked = nurseDto.HoursWorked;
            nurse.YearsOfExperience = nurseDto.YearsOfExperience;
            nurse.LicenseNumber = nurseDto.LicenseNumber;
            await _context.SaveChangesAsync();
        }

    }
}
