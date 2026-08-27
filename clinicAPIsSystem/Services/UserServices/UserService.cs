using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.IUserRepositories;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;
using AutoMapper;
namespace clinicAPIsSystem.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserService userService, IUserRepository userRepository, IMapper mapper)
        {
            _userService = userService;
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
        public async Task<bool> UserExistsAsync(int id)
        {
            return await _userRepository.UserExistsAsync(id);
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userRepository.EmailExistsAsync(email);
        }
        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _userRepository.UsernameExistsAsync(username);
        }

    }
}
