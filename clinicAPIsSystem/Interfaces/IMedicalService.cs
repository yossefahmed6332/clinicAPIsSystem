using clinicAPIsSystem.ClinicDTOs.MedicalDTOs;
namespace clinicAPIsSystem.Interfaces
{
    public interface IMedicalService
    {
        // Create
        public Task<MedicalDto> AddMedicalAsync(CreateMedicalDto medical);

        // Read
        public Task<IEnumerable<MedicalDto>> GetAllMedicalsAsync();
        public Task<MedicalDto?> GetMedicalByIdAsync(int id);

        // Update
        public Task<MedicalDto> UpdateMedicalAsync(UpdateMedicalDto medical);

        // Delete
        public Task DeleteMedicalAsync(int id);
    }
}
