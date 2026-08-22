namespace clinicAPIsSystem.Models.User.Employee
{
    public abstract class Employee:ApplicationUser
    {
        public decimal SalaryPerHour { get;  protected set; }
        public int HoursWorked { get; protected set; }
        public TimeOnly ShiftStart { get; protected set; }
        public TimeOnly ShiftEnd { get; protected set; } 


        public Employee(string firstName, string lastName, string userName, string email,decimal salaryPerHour,int hoursWorked,TimeOnly shiftStart,TimeOnly shiftEnd): base(firstName, lastName, userName, email)
        {
            SalaryPerHour = salaryPerHour;
            HoursWorked = hoursWorked;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
        }

        public Employee()
        {
        }

    }
}
