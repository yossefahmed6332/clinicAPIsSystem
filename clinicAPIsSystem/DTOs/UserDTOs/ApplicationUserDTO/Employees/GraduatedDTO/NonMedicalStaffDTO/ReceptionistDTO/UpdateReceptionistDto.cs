namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ReceptionistDTO
{
    public class UpdateReceptionistDto : UpdateNonMedicalStaffDto
    {
        public UpdateReceptionistDto(string firstName, string lastName, string email, string userName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, string yeatsOfExperience, int graduationYear, string licenseNumber)
: base(firstName, lastName, email, userName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yeatsOfExperience, graduationYear, licenseNumber)
        {
        }
    }
}
