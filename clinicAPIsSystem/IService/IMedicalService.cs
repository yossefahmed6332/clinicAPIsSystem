using clinicAPIsSystem.DTOs.MedicalRecordDTOs;

namespace clinicAPIsSystem.IService
{
    public interface IMedicalService
    {
        public Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto medicalRecord);
        public Task<List<MedicalRecordDto>> GetAllMedicalRecordsAsync();
        public Task<MedicalRecordDto> GetMedicalRecord(int id); 
        public Task<MedicalRecordDto> GetMedicalByPatientIdRecord(int PatientId);
        public Task<MedicalRecordDto> UpdateMedicalRecordAsync(UpdateMedicalRecordDto medicalRecord);
        public Task DeleteMedicalRecordAsync(int id);

    }
}
