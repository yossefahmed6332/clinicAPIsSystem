using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using Microsoft.Identity.Client;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs
{
    public class EmployeeDto:ApplicationUserDto
    {
        public decimal SalaryPerHour { get; set; }
        public int HoursWorked { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
    }
}
