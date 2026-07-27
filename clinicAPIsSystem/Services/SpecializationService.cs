using clinicAPIsSystem.ClinicDTOs.SpecializationDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace clinicAPIsSystem.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ClinicDbContext _context;

        public SpecializationService(ClinicDbContext context)
        {
            _context = context;
        }


        public async Task AddSpecializationAsync(CreateSpecializationDto specialization)
        {
            var spec = new Specialization
            {
                Name = specialization.Name,
                Description = specialization.Description,

            };
        }

        public async Task AssignSpecializationToDoctorAsync(int specializationId, int doctorId)
        {
            var spec = await _context.TSpecializations.FindAsync(specializationId);
            if (spec != null)
            {
                throw new Exception($"Doctor with ID {specializationId} not found");
            }

            var doctor = await _context.TDoctors.FindAsync(specializationId);
            if (doctor != null)
            {
                throw new Exception($"Doctor with Id {doctorId} not found");
            }

        }

        public async Task<IEnumerable<SpecializationDto>> GetAllSpecializationsAsync()
        {
            var specialization = await _context.TSpecializations
                .Select(a => new SpecializationDto
                {
                    Name = a.Name,
                    Description = a.Description,
                }).ToListAsync();

            if (!specialization.Any() || specialization == null)
            {
                throw new Exception($"There is no specialization in system");
            }

            return specialization;

        }

        public async Task<SpecializationDto> GetSpecializationByIdAsync(int id)
        {
            var spec = await _context.TSpecializations.FindAsync(id);

            if (spec == null)
            {
                throw new Exception($"Specialization with Id {id} not found.");
            }
            return new SpecializationDto
            {
                Name = spec.Name,
                Description = spec.Description,
            };

        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationIdAsync(int specializationId)
        {
            var doctors = await _context.TDoctors
                .Where(a => a.SpecializationId == specializationId)
                .Select(a => new DoctorDto
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email!,
                    PhoneNumber = a.PhoneNumber!,
                    SpecializationName = a.Specialization.Name,
                }).ToListAsync();

            if (!doctors.Any() || doctors == null)
            {
                throw new Exception($"There is no doctor with specialization Id {specializationId}");
            }
            return doctors;
        }

        //Update
        public async Task UpdateSpecializationAsync(int id, UpdateSpecializationDto specialization)
        {
            var spec = await _context.TSpecializations.FindAsync(id);

            if (spec == null)
            {
                throw new Exception($"Specialization with Id {id} not found.");
            }
            spec.Name = specialization.Name;
            spec.Description = specialization.Description;

            await _context.SaveChangesAsync();

        }


        //Delete 

        public async Task DeleteSpecializationAsync(int id)
        {
            var spec = await _context.TSpecializations.FindAsync(id);
            if (spec == null)
            {
                throw new Exception($"Specialization with Id {id} not found.");
            }
            _context.TSpecializations.Remove(spec);
            await _context.SaveChangesAsync();
        }

      
    }
}
