using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Interfaces.IUserService; 
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Identity;
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
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
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
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
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
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender
            };
            return userDto;
        }

        //method for updating user information

        public async Task ChangePhoneNumberAsync(string newPhoneNumber, int userId)//change phone number for user
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.PhoneNumber = newPhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update phone number");
            }

        }
        public async Task ChangeEmailAsync(string newEmail, int userId)//change email for user
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Email = newEmail;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update email");
            }
        }

        public async Task ChangePasswordAsync(string currentPassword, string newPassword, int userId)//change password for user
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to change password");
            }
        }


        public async Task ChangeUserNameAsync(string newUserName, int userId)//change username for user
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.UserName = newUserName;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update username");
            }
        }

        public async Task ChangeFirstNameAsync(string newFirstName, int userId)//change first name for user
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FirstName = newFirstName;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update first name");
            }
        }


        public async Task ChangeLastNameAsync(string newLastName, int userId)//change last name for user
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.LastName = newLastName;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update last name");
            }
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
