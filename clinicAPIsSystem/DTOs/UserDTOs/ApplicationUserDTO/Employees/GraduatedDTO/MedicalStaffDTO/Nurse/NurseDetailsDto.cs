
using clinicAPIsSystem.DTOs.VitalSignsDTOs;
using clinicAPIsSystem.DTOs.ExaminationResultDTOs;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.DTOs.AppointmentDTOs;
namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.Nurse
{
    public class NurseDetailsDto:MedicalStaffDto
    {
        public ICollection<VitalSignsDto> VitalSignsRecordedDtos {  get; private set; }
        public ICollection<ExaminationResultDto> ExaminationResultDtos { get; private set; }
        public ICollection<AppointmentDto> AppointmentsDtos { get; private set; }

        public NurseDetailsDto(int id,string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, int yearsOfExperience, int graduationYear, string licenseNumber, string specialization,ICollection<VitalSignsDto> vitalSignsRecorded,ICollection<ExaminationResultDto> examinationResults,ICollection<AppointmentDto> appointments)
    : base(id,userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, licenseNumber, specialization)
        {
            VitalSignsRecordedDtos= vitalSignsRecorded;
            ExaminationResultDtos= examinationResults;
            AppointmentsDtos= appointments;
        }

    }
}
