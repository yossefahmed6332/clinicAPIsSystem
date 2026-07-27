using clinicAPIsSystem.ClinicDTOs.MedicalDTOs;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Models;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
namespace clinicAPIsSystem.Services
{
    public class MedicalService:IMedicalService
    {
        private readonly ClinicDbContext _context;
        public MedicalService(ClinicDbContext context)
        {
            _context = context;
        }
        //create 
        public async Task AddMedicalAsync ( CreateMedicalDto dto)
        {
            var medical = new Medical
            {
                Name = dto.Name,
                TakeTime= dto.TakeTime,
            };
            await _context.TMedicals.AddAsync(medical);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalDto>> GetAllMedicalsAsync()
        {
            var medicals = await _context.TMedicals.ToListAsync();
            if (medicals.Count== 0)
            {
                throw new Exception("No medicals found.");
            }
            return medicals.Select(m => new MedicalDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.TakeTime
            });
        }

        public async Task<MedicalDto> GetMedicalByIdAsync(int id)
        {
            var medical = await _context.TMedicals.FindAsync(id);
            if (medical == null)
            {
                throw new Exception("Medical not found.");
            
            }
            return new MedicalDto
            {
                Id = medical.Id,
                Name = medical.Name,
                Description = medical.TakeTime
            };
        }

        public async Task<MedicalDto> UpdateMedicalAsync(UpdateMedicalDto dto, int id)
        {
            var medical = await _context.TMedicals.FindAsync(id);
            if (medical == null)
            {
                throw new Exception("Medical not found.");
            }
            medical.Name = dto.Name;
            medical.TakeTime = dto.TakeTime;
            await _context.SaveChangesAsync();
            return new MedicalDto
            {
                Id = medical.Id,
                Name = medical.Name,
                Description = medical.TakeTime
            };
        }

        public async Task DeleteMedicalAsync(int id)
        {
            var medical = await _context.TMedicals.FindAsync(id);
            if (medical == null)
            {
                throw new Exception("Medical not found.");
            }
            _context.TMedicals.Remove(medical);
            await _context.SaveChangesAsync();
        }





    }
}
