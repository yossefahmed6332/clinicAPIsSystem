using clinicAPIsSystem.ClinicDTOs.QualificationDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
namespace clinicAPIsSystem.Services.Interfaces
{
    public interface IQualificationService
    {
        // Create
        public Task<QualificationDto> AddQualificationAsync(CreateQualificationDto qualification);
        public Task<bool> AssignQualificationToMedicalStaffAsync(int qualificationId, int medicalStaffId);

        // Read
        public Task<IEnumerable<QualificationDto>> GetAllQualificationsAsync();
        public Task<QualificationDto?> GetQualificationByIdAsync(int id);
        public Task<IEnumerable<MedicalStaffDto>> GetMedicalStaffsByQualificationIdAsync(int qualificationId);

        // Update
        public Task<QualificationDto> UpdateQualificationAsync(UpdateQualificationDto qualification);

        // Delete
        public Task<bool> DeleteQualificationAsync(int id);
        public Task<bool> RemoveQualificationFromMedicalStaffAsync(int qualificationId, int medicalStaffId);
    }
}
