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



    }
    
    
}
