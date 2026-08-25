using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IAppointmentRepository
    {
        public Task<Appointment> ICreateAppointmentAsync();
        public Task<List<Appointment>> IGetAllAppointmentsAsync();
        public Task<Appointment> IGetAppointmentAsync(int id);
        public Task<List<Appointment>> IGetAppointmentsByStatusAsync( AppointmentStatus status);
        public Task<Appointment> IUpdateAppointmentAsync(Appointment appointment);
        public Task IDeleteAppointmentAsync(int id);

    }
}
