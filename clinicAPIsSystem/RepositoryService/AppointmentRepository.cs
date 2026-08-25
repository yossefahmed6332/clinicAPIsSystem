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
        public async Task<Appointment> ICreateAppointmentAsync(Appointment appointment)
        {
            _context.TAppointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<List<Appointment>> IGetAllAppointmentsAsync()
        {
            return await _context.TAppointments.ToListAsync();
        }
        public async Task<Appointment> IGetAppointmentAsync(int id)
        {
            return await _context.TAppointments.FindAsync(id);
        }
        public async Task<List<Appointment>> IGetAppointmentsByStatusAsync(AppointmentStatus status)
        {
            return await _context.TAppointments.Where(a => a.Status == status).ToListAsync();
        }
        public async Task<Appointment> IUpdateAppointmentAsync(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task IDeleteAppointmentAsync(int id)
        {
            var appointment = await _context.TAppointments.FindAsync(id);
            if (appointment != null)
            {
                _context.TAppointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

    }
}
