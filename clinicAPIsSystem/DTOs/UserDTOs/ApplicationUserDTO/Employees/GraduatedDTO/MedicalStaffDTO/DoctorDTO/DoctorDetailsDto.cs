using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.DoctorDTO
{
    public class DoctorDetailsDto:MedicalStaffDto
    {
        public ICollection<PrescriptionDto> PrescriptionDtos { get; private set; }
        public ICollection<AppointmentDto>  AppointmentDtos { get; private set; }
        public DoctorDetailsDto(int id,string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, string yearsOfExperience, int graduationYear, string licenseNumber, string specialization, ICollection<PrescriptionDto> prescriptionDtos, ICollection<AppointmentDto> appointmentDtos)
: base(id,userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, licenseNumber, specialization)
        {
            PrescriptionDtos = prescriptionDtos;
            AppointmentDtos = appointmentDtos;
        }
    }
}
