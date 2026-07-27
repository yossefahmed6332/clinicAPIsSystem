using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.CleanerDTOs;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.NonMedicalStaff;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace clinicAPIsSystem.Services.UserService.NonMedicalStaffService
{
    public class CleanerService : ICleanerService
    {
        private readonly ClinicDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CleanerService(ClinicDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task CreateCleanerAsync(CreateCleanerDto dto)
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
            var Cleaner = new Cleaner
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



            };

            // Create user
            var result = await _userManager.CreateAsync(Cleaner, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine,
                    result.Errors.Select(e => e.Description)));
            }

            // Add roles
            var CleanerRoleResult = await _userManager.AddToRoleAsync(Cleaner, Roles.Cleaner.ToString());
            var userRoleResult = await _userManager.AddToRoleAsync(Cleaner, Roles.User.ToString());

            if (!CleanerRoleResult.Succeeded || !userRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign roles.");
            }
        }

        public async Task<CleanerDto> GetCleanerByIdAsync(int id)
        {
            var cleaner = _context.TCleaners.Find(id);
            if (cleaner == null)
            {
                throw new Exception("Cleaner not found");
            }

            var cleanerDto = new CleanerDto
            {
                Id = cleaner.Id,
                FirstName = cleaner.FirstName,
                LastName = cleaner.LastName,
                UserName = cleaner.UserName!,
                Email = cleaner.Email!,
                PhoneNumber = cleaner.PhoneNumber!,
                Gender = cleaner.Gender,
                SalaryPerHour = cleaner.SalaryPerHour,
                HoursWorked = cleaner.HoursWorked,
                ShiftStart = cleaner.ShiftStart,
                ShiftEnd = cleaner.ShiftEnd,
                CleaningArea = cleaner.CleaningArea,
            };
            return cleanerDto;
        }


        public async Task<IEnumerable<CleanerDto>> GetCleanerByCleaningAreasAsync(string cleaningArea)
        {
            var cleaners =await _context.TCleaners.Where(c => c.CleaningArea == cleaningArea).ToListAsync();
            if (!cleaners.Any())
            {
                throw new Exception("No cleaners found for the specified cleaning area");
            }
            var cleanerDtos = cleaners.Select(c => new CleanerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                UserName = c.UserName!,
                Email = c.Email!,
                PhoneNumber = c.PhoneNumber!,
                Gender = c.Gender,
                SalaryPerHour = c.SalaryPerHour,
                HoursWorked = c.HoursWorked,
                ShiftStart = c.ShiftStart,
                ShiftEnd = c.ShiftEnd,
                CleaningArea = c.CleaningArea,
            });
            return cleanerDtos;
        }

        public async Task UpdateCleanerAsync(int id, UpdateCleanerDto dto)
        {
            var cleaner = await _context.TCleaners.FindAsync(id);
            if (cleaner == null)
            {
                throw new Exception("Cleaner not found");
            }
            // Update properties
            cleaner.FirstName = dto.FirstName;
            cleaner.LastName = dto.LastName;
            cleaner.UserName = dto.UserName;
            cleaner.Email = dto.Email;
            cleaner.PhoneNumber = dto.PhoneNumber;
            cleaner.Gender = dto.Gender;
            cleaner.SalaryPerHour = dto.SalaryPerHour;
            cleaner.HoursWorked = dto.HoursWorked;
            cleaner.CleaningArea = dto.CleaningArea;



        }

        public async Task DeleteCleanerAsync(int cleanerId)
        {
            var cleaner =await _context.TCleaners.FindAsync(cleanerId); 

            if (cleaner==null)
            {
                throw new Exception("Cleaner not found");
            }

            await _userManager.DeleteAsync(cleaner);
            
        }
    }
}