using clinicAPIsSystem.ClinicDTOs.QualificationDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
namespace clinicAPIsSystem.Interfaces
{
    public interface IQualificationService
    {
        // Create
        public Task AddQualificationAsync(CreateQualificationDto qualification);
        public Task AssignQualificationToMedicalStaffAsync(int qualificationId, int medicalStaffId);

        // Read
        public Task<IEnumerable<QualificationDto>> GetAllQualificationsAsync();
        public Task<QualificationDto> GetQualificationByIdAsync(int id);
        public Task<IEnumerable<MedicalStaffDto>> GetMedicalStaffsByQualificationIdAsync(int qualificationId);

        // Update
        public Task UpdateQualificationAsync(int qualificationId, UpdateQualificationDto qualification);

        // Delete
        public Task DeleteQualificationAsync(int id);
    }
}
