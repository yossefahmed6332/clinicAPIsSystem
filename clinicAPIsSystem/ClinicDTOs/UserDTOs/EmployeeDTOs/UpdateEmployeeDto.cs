using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using System.ComponentModel.DataAnnotations;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs
{
    public class UpdateEmployeeDto : UpdateApplicationUserDto
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

