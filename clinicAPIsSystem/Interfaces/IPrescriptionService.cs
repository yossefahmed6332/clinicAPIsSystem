using clinicAPIsSystem.ClinicDTOs.PrescriptionDTOs; 
namespace clinicAPIsSystem.Interfaces
{
    public interface IPrescriptionService
    {
        // Create
        Task<PrescriptionDto> AddPrescriptionAsync(CreatePresciptionDto  prescription);
        Task<bool> AddMedicalToPrescriptionAsync(int prescriptionId, int medicalId);

        // Read
        Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync();
        Task<PrescriptionDto?> GetPrescriptionByIdAsync(int id);
        Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByPatientIdAsync(int patientId);
        Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByDoctorIdAsync(int doctorId);
        public Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByMedicalIdAsync(int medicalId);


        // Update
        Task<PrescriptionDto> UpdatePrescriptionAsync(UpdatePrescriptionDto prescription);

        // Delete
        Task<bool> DeletePrescriptionAsync(int id);
        Task<bool> RemoveMedicalFromPrescriptionAsync(int prescriptionId, int medicalId);
    }
}
