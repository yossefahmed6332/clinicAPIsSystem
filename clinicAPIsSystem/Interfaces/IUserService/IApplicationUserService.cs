using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
namespace clinicAPIsSystem.Interfaces.IUserService
{
    public interface IApplicationUserService
    {
   
        //methods for getting user information
        public Task<ApplicationUserDto> GetUserByIdAsync(int id);
        public Task<ApplicationUserDto> GetUserByUserNameAsync(string userName);
        public Task<ApplicationUserDto> GetUserByEmailAsync(string email);
        public Task AssignUserAsAdminAsync(int userId);


        //methods for changing user information , Async can do it for any user 
        public Task ChangePhoneNumberAsync(string newPhoneNumber, int userId);
        public Task ChangeUserNameAsync(string newUserName, int userId);
        public Task ChangeEmailAsync(string newEmail, int userId);
        public Task ChangePasswordAsync(string currentPassword, string newPassword, int userId);
        public Task ChangeLastNameAsync(string newLastName, int userId);
        public Task ChangeFirstNameAsync(string newFirstName, int userId);//change first name for user




        //method for deleting user 
        public Task DeleteUserAsync(int userId);





    }
}
