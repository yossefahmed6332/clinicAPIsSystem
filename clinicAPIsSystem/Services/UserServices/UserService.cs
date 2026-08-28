using AutoMapper;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.IUserRepositories;
using clinicAPIsSystem.Models.User;
using Microsoft.AspNetCore.Identity;
namespace clinicAPIsSystem.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService( IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationUserDto?> GetUserAsync(int id)
        {
            return _mapper.Map<ApplicationUserDto>(await _userRepository.GetUserAsync(id));
        }
        public async Task<ApplicationUserDto?> GetUserByEmailAsync(string email)
        {
            return _mapper.Map<ApplicationUserDto>(await _userRepository.GetUserByEmailAsync(email));
        }
        public async Task<ApplicationUserDto?> GetUserByUsernameAsync(string username)
        {
            return _mapper.Map<ApplicationUserDto>(await _userRepository.GetUserByUsernameAsync(username));
        }
        public async Task<bool> PhoneNumberExistsAsync(string phoneNumber)
        {
            return await _userRepository.PhoneNumberExistsAsync(phoneNumber);
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userRepository.EmailExistsAsync(email);
        }
        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _userRepository.UsernameExistsAsync(username);
        }

        public async Task ValidateUserCreation(string email, string username, string phoneNumber)
        {
            // Check if the email already exists
            if (await EmailExistsAsync(email))
            {
                throw new ArgumentException("Email already exists.");
            }
            //check if user name is exist 
            if (await UsernameExistsAsync(username))
            {
                throw new ArgumentException("Username already exists.");
            }
            //check if phone number is exist
            if (await PhoneNumberExistsAsync(phoneNumber))
            {
                throw new ArgumentException("Phone number already exists.");
            }
        }
        public async Task ChangePasswordASync(int id, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }
            var result = await _userRepository.ChangePasswordAsync(
                     user,
                     currentPassword,
                      newPassword
                    );

            if (!result.Succeeded)
            {
                throw new ArgumentException(
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );
            }

        }
        public async Task DeleteUserAsync (int id)
        {
           var user =  await _userRepository.GetUserAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"Cannot find user with ID{id}");
            }
            await _userRepository.DeleteUserAsync(user);
        }


    }
}
