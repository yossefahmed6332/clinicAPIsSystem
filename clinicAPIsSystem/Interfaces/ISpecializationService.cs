using clinicAPIsSystem.ClinicDTOs.SpecializationDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs; 
namespace clinicAPIsSystem.Interfaces
{
    public interface ISpecializationService
    {
        // Create
        public Task AddSpecializationAsync(CreateSpecializationDto specialization);
        public Task AssignSpecializationToDoctorAsync(int specializationId, int doctorId);

        // Read
        public Task<IEnumerable<SpecializationDto>> GetAllSpecializationsAsync();
        public Task<SpecializationDto> GetSpecializationByIdAsync(int id);
        public Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationIdAsync(int specializationId);

        // Update
        public Task UpdateSpecializationAsync(int id, UpdateSpecializationDto specialization);

        // Delete
        public Task DeleteSpecializationAsync(int id);
    }
}
