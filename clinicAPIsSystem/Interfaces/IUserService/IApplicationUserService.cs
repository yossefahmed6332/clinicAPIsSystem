using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
namespace clinicAPIsSystem.Interfaces.IUserService
{
    public interface IApplicationUserService
    {
        //method for Create User 
        public Task<ApplicationUserDto> CreateUserAsync(ApplicationUserDto userDto);//call it in EmployeeService & PatientService 

        //methods for getting user information
        public Task<ApplicationUserDto> GetUserByIdAsync(int id);
        public Task<ApplicationUserDto> GetUserByUserNameAsync(string userName);
        public Task<ApplicationUserDto> GetUserByEmailAsync(string email);

        //methods for changing user information , user only do it for himself
        public Task ChangePhoneNumber(string Token, string newPhoneNumber);
        public Task ChangeUserNameAsync(string Token, string newUserName);
        public Task ChangeEmailAsync(string Token, string newEmail);
        public Task ChangePasswordAsync(string Token, string newPassword);

        //methods for changing user information , admin can do it for any user 
        public Task ChangePhoneNumberByAdmin(string newPhoneNumber, int userId);
        public Task ChangeUserNameByAdmin(string newUserName, int userId);
        public Task ChangeEmailByAdmin(string newEmail, int userId);
        public Task ChangePasswordByAdmin(string newPassword, int userId); 

        //method for deleting user 
        public Task DeleteUserAsync(string Token);





    }
}
