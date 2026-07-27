using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
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


        //methods for update user information , Async can do it for any user 
        public Task UpdateUserAsync(UpdateApplicationUserDto userDto,int Id);


        //method for deleting user 
        public Task DeleteUserAsync(int userId);





    }
}
