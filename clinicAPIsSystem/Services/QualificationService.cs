using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.ClinicDTOs.QualificationDTOs;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.MedicalStaff;
using Microsoft.EntityFrameworkCore;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
namespace clinicAPIsSystem.Services
{
    public class QualificationService:IQualificationService
    {
        private readonly ClinicDbContext _context; 
        public QualificationService(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task AddQualificationAsync(CreateQualificationDto qualification)
        {
            var newQualification = new Qualification
            {
                Degree = qualification.Degree,
                University = qualification.University
            };
            await _context.TQualifications.AddAsync(newQualification);
            await _context.SaveChangesAsync();
        }


        public async Task AssignQualificationToMedicalStaffAsync(int qualificationId, int medicalStaffId)
        {
            var qualification = await _context.TQualifications.FindAsync(qualificationId);
            var medicalStaff = await _context.Set<MedicalStaff>().FindAsync(medicalStaffId);

            if (qualification == null )
                throw new Exception("Qualification not found");    
            if (medicalStaff == null)
                throw new Exception("Medical Staff not found");


            medicalStaff.Qualification=qualification;
            await _context.SaveChangesAsync();
        }


        //read 
        public async Task<IEnumerable<QualificationDto>> GetAllQualificationsAsync()
        {
            var qualifications = await _context.TQualifications.AsNoTracking().ToListAsync();

            if (qualifications == null || !qualifications.Any())
                throw new Exception("No qualifications found");

            return qualifications.Select(q => new QualificationDto
            {
                Id = q.Id,
                Degree = q.Degree,
                University = q.University
            });
        }

        public async Task<QualificationDto> GetQualificationByIdAsync(int id)
        {
            var qualification = await _context.TQualifications.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
            if (qualification == null)
                throw new Exception("Qualification not found");
            return new QualificationDto
            {
                Id = qualification.Id,
                Degree = qualification.Degree,
                University = qualification.University
            };
        }


        public async Task<IEnumerable<MedicalStaffDto>> GetMedicalStaffsByQualificationIdAsync(int qualificationId)
        {
            var medicalStaffs = await _context.Set<MedicalStaff>()
                .Where(ms => ms.Qualification.Id == qualificationId)
                .Select(ms => new MedicalStaffDto
                {
                    //ApplicationUser data 
                    Id = ms.Id,
                    UserName=ms.UserName!,
                    Email=ms.Email!, 
                    PhoneNumber=ms.PhoneNumber!, 
                    FirstName=ms.FirstName!,
                    LastName=ms.LastName!,
                    //employee 
                    SalaryPerHour=ms.SalaryPerHour!,
                    HoursWorked=ms.HoursWorked!,
                    ShiftStart=ms.ShiftStart!,
                    ShiftEnd=ms.ShiftEnd!,
                    //medical staff 
                    LicenseNumber=ms.LicenseNumber!,
                    YearsOfExperience=ms.YearsOfExperience!,
                })
                .ToListAsync();
            if (medicalStaffs == null || !medicalStaffs.Any())
                throw new Exception("No medical staff found for the given qualification");
            return medicalStaffs;
        }

        //update
        public async Task UpdateQualificationAsync(int qualificationId, UpdateQualificationDto qualification)
        {
            var Qualification = await _context.TQualifications.FindAsync(qualificationId);
            if (Qualification == null)
                throw new Exception("Qualification not found");
            Qualification.Degree = qualification.Degree;
            Qualification.University = qualification.University;
            await _context.SaveChangesAsync();
        }

        //delete

        public async Task DeleteQualificationAsync(int id)
        {
            var qualification = await _context.TQualifications.FindAsync(id);
            if (qualification == null)
                throw new Exception("Qualification not found");
            _context.TQualifications.Remove(qualification);
            await _context.SaveChangesAsync();
        }

    
    }

}
