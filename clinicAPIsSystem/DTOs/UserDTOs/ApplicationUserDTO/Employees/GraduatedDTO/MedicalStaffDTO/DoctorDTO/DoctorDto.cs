namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.DoctorDTO
{
    public class DoctorDto:MedicalStaffDto
    {
        public DoctorDto(int id,string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, string yearsOfExperience, int graduationYear, string licenseNumber, string specialization)
: base(id,userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, licenseNumber, specialization)
        {
        }
    }
}
