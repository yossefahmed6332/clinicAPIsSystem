using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees; 
namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.CleanerDTO
{
    public class CleanerDto:EmployeeDto
    {
        public CleanerDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd)
              : base(id, userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd)
        {
            
        }
    }
}
