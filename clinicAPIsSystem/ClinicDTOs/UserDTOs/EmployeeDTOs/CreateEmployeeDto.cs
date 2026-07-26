using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Models.User;
using System.ComponentModel.DataAnnotations;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs
{
    public class CreateEmployeeDto:CreateApplicationUserDto
    {
        [Required]
        public decimal SalaryPerHour { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        public TimeOnly ShiftStart { get; set; }

        [Required]
        public TimeOnly ShiftEnd { get; set; }
    }
}
