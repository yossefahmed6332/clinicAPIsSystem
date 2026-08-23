using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees
{
    public abstract class CreateEmployeeDto: CreateApplicationUserDto
    {
        [Required,Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal SalaryPerHour { get; protected set; }
        [Required,Range(0, int.MaxValue)]
        public int HoursWorked {  get; protected set; }
        [Required]
        public TimeOnly ShiftStart {  get;protected set; }
        [Required]
        public TimeOnly ShiftEnd { get;protected set; }


        public CreateEmployeeDto(string firstName, string lastName, string email, string userName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd)
            : base(firstName, lastName, email, userName, phoneNumber)
        {
            SalaryPerHour = salaryPerHour;
            HoursWorked = hoursWorked;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
        }
    }
    
    
}
