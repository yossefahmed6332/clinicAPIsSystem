using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IVitalSignsRepository
    {
        public Task<VitalSigns> ICreateVitalSignsAsync();
        public Task<List<VitalSigns>> IGetAllVitalSignsAsync();
        public Task<VitalSigns> IGetVitalSignsAsync(int id);
        public Task<List<VitalSigns>> IGetVitalSignsByPatientIdAsync(int patientId);
        public Task<List<VitalSigns>> IGetVitalSignsByNurseIdAsync(int nurseId);
        public Task<VitalSigns> IUpdateVitalSignsAsync(VitalSigns vitalSigns);
        public Task IDeleteVitalSignsAsync(int id);
    }
}
