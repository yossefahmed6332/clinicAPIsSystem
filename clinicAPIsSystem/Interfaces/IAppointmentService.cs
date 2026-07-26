using clinicAPIsSystem.ClinicDTOs.AppointmentDTOs;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Services.Interfaces
{
    public interface IAppointmentService
    {
        // Create
        public Task<AppointmentDto> AddAppointmentAsync(CreateAppointmentDto appointment);

        // Read
        public Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        public Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        public Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId);
        public Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId);
        public Task <IEnumerable<AppointmentDto>> GetAppointmentsByPatientAndDoctorAsync(int patientId, int doctorId);
        public Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(AppointmentStatus status);

        // Update
        public Task<AppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto appointment);
        public Task<bool> UpdateAppointmentStatusAsync(int appointmentId, AppointmentStatus status);

        // Delete
        public Task<bool> DeleteAppointmentAsync(int id);
    }
}
