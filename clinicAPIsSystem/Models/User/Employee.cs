namespace clinicAPIsSystem.Models.User
{
    public abstract class Employee : ApplicationUser
    {
        public decimal SalaryPerHour { get; set; } 
        public decimal HoursWorked { get; set; } 
        public TimeOnly ShiftStart { get; set; } 
        public TimeOnly ShiftEnd { get; set; } 

    }
}
