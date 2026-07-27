using clinicAPIsSystem.ClinicDTOs.PrescriptionDTOs; 
namespace clinicAPIsSystem.Interfaces
{
    public interface IPrescriptionService
    {
        // Create
        public Task AddPrescriptionAsync(CreatePresciptionDto  prescription);
        public Task AddMedicalToPrescriptionAsync(int prescriptionId, int medicalId);

        // Read
        public Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync();
        public Task<PrescriptionDto> GetPrescriptionByIdAsync(int id);
        public Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByPatientIdAsync(int patientId);
        public Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByDoctorIdAsync(int doctorId);
        public Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByMedicalIdAsync(int medicalId);


        // Update
        public Task UpdatePrescriptionAsync(int prescriptionId, PrescriptionDto updatedPrescription);

        // Delete
        public Task DeletePrescriptionAsync(int id);
        public Task RemoveMedicalFromPrescriptionAsync(int prescriptionId, int medicalId);
    }
}
