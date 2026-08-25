using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository.INonMedicalStaffRepository
{
    public interface IManagerRepository
    {
        public Task<Manager> ICreateManagerAsync();
        public Task<List<Manager>> IGetAllManagersAsync();
        public Task<Manager> IGetManagerAsync(int id);
        public Task<Manager> IUpdateManagerAsync(Manager manager);
        public Task IDeleteManagerAsync(int id);
    }
}
