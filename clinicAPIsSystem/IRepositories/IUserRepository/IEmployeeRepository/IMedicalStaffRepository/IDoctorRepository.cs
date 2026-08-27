using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository.IEmployeeRepository.IMedicalStaffRepository
{
    public interface IDoctorRepository
    {
        public Task<(Doctor doctor, bool addUserRes, bool addPasswordRes, bool addRoleRes)> CreateDoctorAsync(Doctor doctor, string password);
        public Task<List<Doctor>> IGetAllDoctorsAsync();
        public Task<Doctor?> IGetDoctorAsync(int id);
        public Task<(ICollection<Appointment> appointments, ICollection<Prescription> prescriptions)> IGetDoctorWithDetailsAsync(int id);
        public Task<Doctor> IUpdateDoctorAsync(Doctor doctor);
        public Task IDeleteDoctorAsync(Doctor doctor); 
    }
}
