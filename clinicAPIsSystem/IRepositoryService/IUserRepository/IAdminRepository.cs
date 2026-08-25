using clinicAPIsSystem.Models.User;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository
{
    public interface IAdminRepository
    {
        public Task<Admin> ICreateAdminAsync();
        public Task<List<Admin>> IGetAllAdminsAsync();
        public Task<Admin> IGetAdminAsync(int id);
        public Task<Admin> IUpdateAdminAsync(Admin admin);
        public Task IDeleteAdminAsync(int id);

    }
}
