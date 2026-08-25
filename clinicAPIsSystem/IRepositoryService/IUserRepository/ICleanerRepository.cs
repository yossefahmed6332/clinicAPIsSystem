using clinicAPIsSystem.Models.User.Employee;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository
{
    public interface ICleanerRepository
    {
        public Task<Cleaner> ICreateCleanerAsync();
        public Task<List<Cleaner>> IGetAllCleanersAsync();
        public Task<Cleaner> IGetCleanerAsync(int id);
        public Task<Cleaner> IUpdateCleanerAsync(Cleaner cleaner);
        public Task IDeleteCleanerAsync(int id);
    }
}
