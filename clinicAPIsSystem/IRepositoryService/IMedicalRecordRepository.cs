using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IMedicalRecordRepository
    {
        public Task<MedicalRecord> ICreateMedicalRecordAsync();
        public Task<List<MedicalRecord>> IGetAllMedicalRecordsAsync();
        public Task<MedicalRecord> IGetMedicalRecordAsync(int id);
        public Task<MedicalRecord> IGetMedicalRecordsByPatientIdAsync(int patientId);
        public Task<MedicalRecord> IUpdateMedicalRecordAsync(MedicalRecord medicalRecord);
        public Task IDeleteMedicalRecordAsync(int id);

    }
}
