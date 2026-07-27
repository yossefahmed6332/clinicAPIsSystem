using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.ClinicDTOs.AppointmentDTOs;
using clinicAPIsSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace clinicAPIsSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ClinicDbContext _context;
        public AppointmentService(ClinicDbContext context)
        {
            _context = context;
        }

        //create method 
        public async Task CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Status = AppointmentStatus.Pending,
                AppointmentDate = dto.AppointmentTime,
                Reason = dto.Reason,
                Note = dto.Note,
            };
            _context.TAppointments.Add(appointment);
            await _context.SaveChangesAsync();

        }



        //read method
        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()//get all 
        {
            var appointments = await _context.TAppointments.ToListAsync();
            if (appointments.Count == 0)
            {
                throw new KeyNotFoundException("No appointments found.");
            }
            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Status = a.Status,
                AppointmentDate = a.AppointmentDate,
                Reason = a.Reason,
                Note = a.Note
            });
        }


        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)//get by id
        {
            var appointment = await _context.TAppointments.FindAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            return new AppointmentDto
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                Status = appointment.Status,
                AppointmentDate = appointment.AppointmentDate,
                Reason = appointment.Reason,
                Note = appointment.Note
            };
        }


        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId)//get by doctor id
        {
            var appointments = await _context.TAppointments.Where(a => a.DoctorId == doctorId).ToListAsync();
            if (appointments.Count == 0)
            {
                throw new KeyNotFoundException($"No appointments found for doctor with ID {doctorId}.");
            }
            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Status = a.Status,
                AppointmentDate = a.AppointmentDate,
                Reason = a.Reason,
                Note = a.Note
            });
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId)//get by patient id
        {
            var appointments = await _context.TAppointments.Where(a => a.PatientId == patientId).ToListAsync();
            if (appointments.Count == 0)
            {
                throw new KeyNotFoundException($"No appointments found for patient with ID {patientId}.");
            }
            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Status = a.Status,
                AppointmentDate = a.AppointmentDate,
                Reason = a.Reason,
                Note = a.Note
            });
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientAndDoctorAsync(int patientId, int doctorId)//get by patient and doctor id
        {
            var appointments = await _context.TAppointments.Where(a => a.PatientId == patientId && a.DoctorId == doctorId).ToListAsync();
            if (appointments.Count == 0)
            {
                throw new KeyNotFoundException($"No appointments found for patient with ID {patientId} and doctor with ID {doctorId}.");
            }
            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Status = a.Status,
                AppointmentDate = a.AppointmentDate,
                Reason = a.Reason,
                Note = a.Note
            });
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(AppointmentStatus status)//get by status
        {
            var appointments = await _context.TAppointments.Where(a => a.Status == status).ToListAsync();
            if (appointments.Count == 0)
            {
                throw new KeyNotFoundException($"No appointments found with status {status}.");
            }
            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Status = a.Status,
                AppointmentDate = a.AppointmentDate,
                Reason = a.Reason,
                Note = a.Note
            });
        }


        //update method
        public async Task UpdateAppointmentStatusAsync(int id, AppointmentStatus status)
        {
            var appointment = await _context.TAppointments.FindAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            appointment.Status = status;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAppointmentAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _context.TAppointments.FindAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            appointment.DoctorId = dto.DoctorId;
            appointment.PatientId = dto.PatientId;
            appointment.AppointmentDate = dto.AppointmentTime;
            appointment.Reason = dto.Reason;
            appointment.Note = dto.Note;
            await _context.SaveChangesAsync();
        }

        //delete method
        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.TAppointments.FindAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            _context.TAppointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }






    }
}
