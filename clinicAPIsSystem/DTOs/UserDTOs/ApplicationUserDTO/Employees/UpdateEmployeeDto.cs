using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees
{
    public class UpdateEmployeeDto : UpdateApplicationUserDto
    {
        [Required, Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal SalaryPerHour { get; private set; }
        [Required, Range(0, int.MaxValue)]
        public int HoursWorked { get; private set; }
        [Required]
        public TimeOnly ShiftStart { get; private set; }
        [Required]
        public TimeOnly ShiftEnd { get; private set; }


        public UpdateEmployeeDto(string firstName, string lastName, string email, string userName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd)
            : base(firstName, lastName, email, userName, phoneNumber)
        {
            SalaryPerHour = salaryPerHour;
            HoursWorked = hoursWorked;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
        }
    }


}
