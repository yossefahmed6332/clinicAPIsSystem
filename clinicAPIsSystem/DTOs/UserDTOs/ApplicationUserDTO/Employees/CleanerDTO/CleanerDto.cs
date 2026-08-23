using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees; 
namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.CleanerDTO
{
    public class CleanerDto:EmployeeDto
    {
        public CleanerDTO(string firstName, string lastName, string email, string userName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd)
            : base(firstName, lastName, email, userName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd)
        {
        }
    }
}
