using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Interfaces.IUserService; 
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace clinicAPIsSystem.Services.UserService
{
    public class ApplicationUserService:IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public ApplicationUserService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users
                .Select(a => new ApplicationUserDto
                {
                    Id = a.Id,
                    UserName = a.UserName!,
                    Email = a.Email!,
                    PhoneNumber = a.PhoneNumber!,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                })
                .ToListAsync();

            return users;
        }

        public async Task AssignUserAsAdminAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            // Check if the Admin role exists, if not, create it
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
            }
            // Assign the Admin role to the user
            await _userManager.AddToRoleAsync(user, "Admin");
        }
        //method for getting user information
        public async Task<ApplicationUserDto> GetUserByIdAsync(int id)//get User by Id 
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            var userDto = new ApplicationUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Gender = user.Gender
            };

            return userDto;
        }

        public async Task<ApplicationUserDto> GetUserByUserNameAsync(string userName)//get User by UserName 
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userDto = new ApplicationUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Gender = user.Gender
            }; 
            return userDto;
        }

        public async Task<ApplicationUserDto> GetUserByEmailAsync(string email)//get User by Email 
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userDto = new ApplicationUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Gender = user.Gender
            };
            return userDto;
        }

        //method for updating user information
        public async Task UpdateUserAsync(UpdateApplicationUserDto dto,int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found");
            }

            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.FirstName = dto.FirstName;
            user.LastName= dto.LastName;

        }
        

        public async Task DeleteUserAsync(int userId)//delete user by id
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete user");
            }
        }





    }
}
