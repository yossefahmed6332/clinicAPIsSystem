using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository.INonMedicalStaffRepository
{
    public interface IAccountantRepository
    {
        public Task<Accountant> ICreateAccountantAsync();
        public Task<List<Accountant>> IGetAllAccountantsAsync();
        public Task<Accountant> IGetAccountantAsync(int id); 
        public Task<Accountant> IUpdateAccountantAsync(Accountant accountant);
        public Task IDeleteAccountantAsync(int id);
    }
}
