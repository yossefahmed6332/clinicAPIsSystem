using clinicAPIsSystem.ClinicDTOs.PrescriptionDTOs;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicAPIsSystem.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly ClinicDbContext _context;
        public PrescriptionService(ClinicDbContext context)
        {
            _context = context;
        }
        //create 
        public async Task AddPrescriptionAsync(CreatePresciptionDto prescription)
        {
            var newPrescription = new Prescription
            {
                PatientId = prescription.PatientId,
                DoctorId = prescription.DoctorId,
                Diagnosis = prescription.Diagnosis,

            };
            _context.TPrescriptions.Add(newPrescription);
            await _context.SaveChangesAsync();

        }

        public async Task AddMedicalToPrescriptionAsync(int prescriptionId, int medicalId)
        {
            var prescription = await _context.TPrescriptions
                .Include(p => p.Medicals)
                .FirstOrDefaultAsync(p => p.Id == prescriptionId);
            if (prescription == null)
            {
                throw new Exception("Prescription not found");
            }
            var medical = await _context.TMedicals.FindAsync(medicalId);
            if (medical == null)
            {
                throw new Exception("Medical not found");
            }
            prescription.Medicals.Add(medical);
            await _context.SaveChangesAsync();
        }

        public async Task<PrescriptionDto> GetPrescriptionByIdAsync(int prescriptionId)
        {
            var prescription = await _context.TPrescriptions.FindAsync(prescriptionId);
            if (prescription == null)
            {
                throw new Exception("Prescription not found");
            }
            return new PrescriptionDto
            {
                Id = prescription.Id,
                PatientId = prescription.PatientId,
                DoctorId = prescription.DoctorId,
                Diagnosis = prescription.Diagnosis
            };
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync()
        {
            return await _context.TPrescriptions.Select(p => new PrescriptionDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                DoctorId = p.DoctorId,
                Diagnosis = p.Diagnosis
            }).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByPatientIdAsync(int patientId)
        {
            return await _context.TPrescriptions
                .Where(p => p.PatientId == patientId)
                .Select(p => new PrescriptionDto
                {
                    Id = p.Id,
                    PatientId = p.PatientId,
                    DoctorId = p.DoctorId,
                    Diagnosis = p.Diagnosis
                }).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByDoctorIdAsync(int doctorId)
        {
            return await _context.TPrescriptions
                .Where(p => p.DoctorId == doctorId)
                .Select(p => new PrescriptionDto
                {
                    Id = p.Id,
                    PatientId = p.PatientId,
                    DoctorId = p.DoctorId,
                    Diagnosis = p.Diagnosis
                }).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByMedicalIdAsync(int medicalId)
        {
            return await _context.TPrescriptions
                .Where(p => p.Medicals.Any(m => m.Id == medicalId))
                .Select(p => new PrescriptionDto
                {
                    Id = p.Id,
                    PatientId = p.PatientId,
                    DoctorId = p.DoctorId,
                    Diagnosis = p.Diagnosis
                }).ToListAsync();
        }


        public async Task UpdatePrescriptionAsync(int prescriptionId, UpdatePrescriptionDto updatedPrescription)
        {
            var prescription = await _context.TPrescriptions.FindAsync(prescriptionId);
            if (prescription == null)
            {
                throw new Exception("Prescription not found");
            }
            prescription.PatientId = updatedPrescription.PatientId;
            prescription.DoctorId = updatedPrescription.DoctorId;
            prescription.Diagnosis = updatedPrescription.Diagnosis;
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrescriptionAsync(int prescriptionId, PrescriptionDto updatedPrescription)
        {
            var prescription = await _context.TPrescriptions.FindAsync(prescriptionId);

            if (prescription == null)
            {
                throw new Exception("Prescription not found");
            }
            //change data 
            prescription.PatientId = updatedPrescription.PatientId;
            prescription.DoctorId = updatedPrescription.DoctorId;
            prescription.Diagnosis = updatedPrescription.Diagnosis;
            await _context.SaveChangesAsync();

        }


        public async Task DeletePrescriptionAsync(int prescriptionId)
        {
            var prescription = await _context.TPrescriptions.FindAsync(prescriptionId);
            if (prescription == null)
            {
                throw new Exception("Prescription not found");
            }
            _context.TPrescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
        }

        
        public async Task RemoveMedicalFromPrescriptionAsync(int prescriptionId, int medicalId)
        {
            var prescription = await _context.TPrescriptions
                .Include(p => p.Medicals)
                .FirstOrDefaultAsync(p => p.Id == prescriptionId);
            if (prescription == null)
            {
                throw new Exception("Prescription not found");
            }
            var medical = prescription.Medicals.FirstOrDefault(m => m.Id == medicalId);
            if (medical == null)
            {
                throw new Exception("Medical not found in the prescription");
            }
            prescription.Medicals.Remove(medical);
            await _context.SaveChangesAsync();
        }

    }
}
