using clinicAPIsSystem.Models.User;
namespace clinicAPIsSystem.IUserRepositories
{
   
    public interface IUserRepository
    {
        //get user 
        public Task<ApplicationUser?> GetUserAsync(int id);

        public Task<ApplicationUser?> GetUserByEmailAsync(string email);

        public Task<ApplicationUser?> GetUserByUsernameAsync(string username);
        //this is to check if user exists
        public Task<bool> PhoneNumberExistsAsync(string phoneNumber);

        public Task<bool> EmailExistsAsync(string email);

        public Task<bool> UsernameExistsAsync(string username);

        //delete user 
        public Task DeleteUserAsync (ApplicationUser user);
        
    }
}
