using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;
namespace clinicAPIsSystem.IServices.IUserServices
{
    public interface IUserService
    {
        //get user 
        public Task<ApplicationUserDto?> GetUserAsync(int id);

        public Task<ApplicationUserDto?> GetUserByEmailAsync(string email);

        public Task<ApplicationUserDto?> GetUserByUsernameAsync(string username);
        //this is to check if user exists
        public Task<bool> UserExistsAsync(int id);

        public Task<bool> EmailExistsAsync(string email);

        public Task<bool> UsernameExistsAsync(string username);
    }
}
