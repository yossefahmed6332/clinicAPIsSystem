using clinicAPIsSystem.ClinicDTOs.OperationDtos;
namespace clinicAPIsSystem.Services.Interfaces
{
    public interface IOperationService
    {
        // Create
        public Task<OperationDto> AddOperationAsync(CreateOperationDto operation);

        // Read
        public Task<IEnumerable<OperationDto>> GetAllOperationsAsync();
        public Task<OperationDto?> GetOperationByIdAsync(int id);
        public Task<IEnumerable<OperationDto>> GetOperationsByPatientIdAsync(int patientId);
        public Task<IEnumerable<OperationDto>> GetOperationsByAccountantIdAsync(int accountantId);
        public Task<IEnumerable<OperationDto>> GetOperationsByAppointmentIdAsync(int appointmentId);

        // Delete
        public Task<bool> DeleteOperationAsync(int id);
    }
}
