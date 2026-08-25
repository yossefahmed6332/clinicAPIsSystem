using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository.IMedicalStaffRepository
{
    public interface INurseRepository
    {
        public Task<Nurse> ICreateNurseAsync();
        public Task<List<Nurse>> IGetAllNursesAsync();
        public Task<Nurse> IGetNurseAsync(int id);
        public Task<( ICollection<VitalSigns> vitalSignsRecorded, ICollection<ExaminationResult> examinationResults, ICollection<Appointment> appointments)> IGetNurseWithDetailsAsync(int id);
        public Task<Nurse> IUpdateNurseAsync(Nurse nurse);
        public Task IDeleteNurseAsync(int id);
    }
}
