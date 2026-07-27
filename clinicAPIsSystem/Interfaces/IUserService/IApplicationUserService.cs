using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Interfaces.IUserService
{
    public interface IApplicationUserService
    {
        //create 
        public Task AssignUserAsAdminAsync(int userId);


        //methods for getting user information
        public Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync();
        public Task<ApplicationUserDto> GetUserByIdAsync(int id);
        public Task<ApplicationUserDto> GetUserByUserNameAsync(string userName);
        public Task<ApplicationUserDto> GetUserByEmailAsync(string email);
        public Task<IEnumerable<ApplicationUserDto>> GetUserByRole(Roles role);


        //methods for update user information , Async can do it for any user 
        public Task UpdateUserAsync(UpdateApplicationUserDto userDto,int Id);


        //method for deleting user 
        public Task DeleteUserAsync(int userId);





    }
}
