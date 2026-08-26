using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IAppointmentRepository
    {
        public Task<Appointment> CreateAppointmentAsync(Appointment appointment);
        public Task<List<Appointment>> GetAllAppointmentsAsync();
        public Task<Appointment> GetAppointmentAsync(int id);
        public Task<List<Appointment>> GetAppointmentsByStatusAsync( AppointmentStatus status);
        public Task<Appointment> GetAppointmentInTimeRange(DateTime startDate, DateTime endDate, int doctorId);
        public Task<Appointment> UpdateAppointmentAsync(Appointment appointment);
        public Task DeleteAppointmentAsync(Appointment appointment);

    }
}
