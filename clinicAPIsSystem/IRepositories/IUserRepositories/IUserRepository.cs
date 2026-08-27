using clinicAPIsSystem.Models.User;
namespace clinicAPIsSystem.IUserRepositories
{
    public interface IUserRepository
    {
        public Task<ApplicationUser?> GetUserAsync(int id);

        public Task<ApplicationUser?> GetUserByEmailAsync(string email);

        public Task<ApplicationUser?> GetUserByUsernameAsync(string username);

        public Task<bool> UserExistsAsync(int id);

        public Task<bool> EmailExistsAsync(string email);

        public Task<bool> UsernameExistsAsync(string username);
    }
}
