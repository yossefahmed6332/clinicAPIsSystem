using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using System.ComponentModel.DataAnnotations;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs
{
    public class UpdateEmployeeDto : UpdateApplicationUserDto
    {
        [Required, Range(typeof(decimal), "1", "79228162514264337593543950335")]
        public decimal SalaryPerHour { get; set; }

        [Required, Range(0, int.MaxValue)]

        public int HoursWorked { get; set; }

        [Required]
        public TimeOnly ShiftStart { get; set; }

        [Required]
        public TimeOnly ShiftEnd { get; set; }
    }
    }

