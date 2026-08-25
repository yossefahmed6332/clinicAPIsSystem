using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository.INonMedicalStaffRepository
{
    public interface IReceptionistRepository
    {
        public Task<(Receptionist receptionist, bool addUserRes, bool addPasswordRes, bool addRoleRes)> ICreateReceptionistAsync(Receptionist receptionist, string password);
        public Task<List<Receptionist>> IGetAllReceptionistsAsync();
        public Task<Receptionist> IGetReceptionistAsync(int id);
        public Task<Receptionist> IUpdateReceptionistAsync(Receptionist receptionist);
        public Task IDeleteReceptionistAsync(Receptionist receptionist);
    }
}
