namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ManagerDTO
{
    public class CreateManagerDto:CreateNonMedicalStaffDto
    {
        public CreateManagerDto(string firstName, string lastName, string email, string userName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, int yeatsOfExperience, int graduationYear, string licenseNumber)
            : base(firstName, lastName, email, userName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yeatsOfExperience, graduationYear, licenseNumber)
        {
        }
    }
}
