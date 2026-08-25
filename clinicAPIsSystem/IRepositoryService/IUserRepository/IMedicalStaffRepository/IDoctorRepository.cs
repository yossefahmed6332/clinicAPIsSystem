using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository.IMedicalStaffRepository
{
    public interface IDoctorRepository
    {
        public Task<Doctor> ICreateDoctorAsync();
        public Task<List<Doctor>> IGetAllDoctorsAsync();
        public Task<Doctor> IGetDoctorAsync(int id);
        public Task<(ICollection<Appointment> appointments, ICollection<Prescription> prescriptions)> IGetDoctorWithDetailsAsync(int id);
        public Task<Doctor> IUpdateDoctorAsync(Doctor doctor);
        public Task IDeleteDoctorAsync(int id); 
    }
}
