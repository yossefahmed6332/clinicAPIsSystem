using clinicAPIsSystem.ClinicDTOs.AppointmentDTOs;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Interfaces
{
    public interface IAppointmentService
    {
        // Create
        public Task CreateAppointmentAsync(CreateAppointmentDto appointment);

        // Read
        public Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        public Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        public Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId);
        public Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId);
        public Task <IEnumerable<AppointmentDto>> GetAppointmentsByPatientAndDoctorAsync(int patientId, int doctorId);
        public Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(AppointmentStatus status);
        
        // Update
        public Task UpdateAppointmentAsync(int id, UpdateAppointmentDto appointment);
        public Task UpdateAppointmentStatusAsync(int appointmentId, AppointmentStatus status);
        // Delete
        public Task DeleteAppointmentAsync(int id);
    }
}
