using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Data;
using Microsoft.EntityFrameworkCore;
namespace clinicAPIsSystem.RepositoryService
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly ClinicDbContext _context;
        public AppointmentRepository(ClinicDbContext context)
        {
            _context = context;
        }
        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
           await _context.TAppointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.TAppointments.ToListAsync();
        }
        public async Task<Appointment> GetAppointmentAsync(int id)
        {
            return await _context.TAppointments.FindAsync(id);
        }
        public async Task<List<Appointment>> GetAppointmentsByStatusAsync(AppointmentStatus status)
        {
            return await _context.TAppointments.Where(a => a.Status == status).ToListAsync();
        }
        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
        {
            _context.TAppointments.Update(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task DeleteAppointmentAsync(Appointment appointment)
        {
            _context.TAppointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

    }
}
