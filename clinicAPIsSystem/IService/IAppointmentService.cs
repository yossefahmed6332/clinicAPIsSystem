using clinicAPIsSystem.DTOs.AppointmentDTOs;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IService
{
    public interface IAppointmentService
    {
        public Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto appointment);
        public Task<List<AppointmentDto>> GetAllAppointmentsAsync();
        public Task<AppointmentDto> GetAppointmentAsync(int id);
        public Task<List<AppointmentDto>> GetAppointmentsByStatusAsync(AppointmentStatus status);
        public Task<AppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto appointment);
        public Task DeleteAppointmentAsync(int  id);
    }
}
