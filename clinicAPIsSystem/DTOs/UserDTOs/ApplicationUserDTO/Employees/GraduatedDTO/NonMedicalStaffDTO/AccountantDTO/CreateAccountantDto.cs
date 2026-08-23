namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.AccountantDTO
{
    public class CreateAccountantDto:CreateNonMedicalStaffDto
    {
        public CreateAccountantDto(string firstName, string lastName, string email, string userName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, string yeatsOfExperience, int graduationYear, string licenseNumber)
            : base(firstName, lastName, email, userName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yeatsOfExperience, graduationYear, licenseNumber)
        {
        }
    }
}
