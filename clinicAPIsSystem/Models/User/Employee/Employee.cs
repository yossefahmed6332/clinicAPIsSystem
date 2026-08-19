namespace clinicAPIsSystem.Models.User.Employee
{
    public abstract class Employee:ApplicationUser
    {
        public decimal SalaryPerHour { get;  set; }
        public int HoursWorked { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; } 

    }
}
