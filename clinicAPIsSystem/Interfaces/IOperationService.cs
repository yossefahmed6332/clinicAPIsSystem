using clinicAPIsSystem.ClinicDTOs.OperationDtos;
namespace clinicAPIsSystem.Interfaces { 
    public interface IOperationService
    {
        // Create
        public Task AddOperationAsync(CreateOperationDto operation);

        // Read
        public Task<IEnumerable<OperationDto>> GetAllOperationsAsync();
        public Task<OperationDto> GetOperationByIdAsync(int id);
        public Task<IEnumerable<OperationDto>> GetOperationsByPatientIdAsync(int patientId);
        public Task<IEnumerable<OperationDto>> GetOperationsByReceptionistIdAsync(int ReceptionistId);
        public Task<IEnumerable<OperationDto>> GetOperationsByAppointmentIdAsync(int appointmentId);

        // Delete
    }
}
