namespace clinicAPIsSystem.Models.User
{
    public class Employee : ApplicationUser
    {
        public decimal SalaryPerHour { get; set; } 
        public int HoursWorked { get; set; } 
        public TimeOnly ShiftStart { get; set; } 
        public TimeOnly ShiftEnd { get; set; } 

    }
}
