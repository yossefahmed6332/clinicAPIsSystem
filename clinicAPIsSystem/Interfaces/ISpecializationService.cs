using clinicAPIsSystem.ClinicDTOs.SpecializationDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs; 
namespace clinicAPIsSystem.Interfaces
{
    public interface ISpecializationService
    {
        // Create
        public Task<SpecializationDto> AddSpecializationAsync(CreateSpecializationDto specialization);
        public Task<bool> AssignSpecializationToDoctorAsync(int specializationId, int doctorId);

        // Read
        public Task<IEnumerable<SpecializationDto>> GetAllSpecializationsAsync();
        public Task<SpecializationDto?> GetSpecializationByIdAsync(int id);
        public Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationIdAsync(int specializationId);

        // Update
        public Task<SpecializationDto> UpdateSpecializationAsync(UpdateSpecializationDto specialization);

        // Delete
        public Task<bool> DeleteSpecializationAsync(int id);
        public Task<bool> RemoveSpecializationFromDoctorAsync(int specializationId, int doctorId);
    }
}
