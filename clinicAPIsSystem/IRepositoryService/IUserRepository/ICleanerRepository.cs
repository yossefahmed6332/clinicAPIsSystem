using clinicAPIsSystem.Models.User.Employee;





















































namespace clinicAPIsSystem.IRepositoryService.IUserRepository
{
    public interface ICleanerRepository
    {
        public Task<(Cleaner cleaner, bool addUserRes, bool addPasswordRes, bool addRoleRes)> CreateCleanerAsync(Cleaner cleaner,string password);
        public Task<List<Cleaner>> GetAllCleanersAsync();
        public Task<Cleaner> GetCleanerAsync(int id);
        public Task<Cleaner> UpdateCleanerAsync(Cleaner cleaner);
        public Task DeleteCleanerAsync(Cleaner Cleaner);
    }
}
