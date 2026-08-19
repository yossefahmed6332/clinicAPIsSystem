namespace clinicAPIsSystem.Models.User.Employee
{
    public abstract class Employee:ApplicationUser
    {
        protected decimal SalaryPerHour { get; set; }
        protected int HoursWorked { get; set; }
        protected TimeOnly ShiftStart { get; set; }
        protected TimeOnly ShiftEnd { get; set; } 

    }
}
