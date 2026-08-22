namespace clinicAPIsSystem.Models.User.Employee
{
    public class Cleaner:Employee
    {
        public Cleaner(string firstName, string lastName, string userName, string email,decimal salaryPerHour,int hoursWorked,TimeOnly shiftStart,TimeOnly shiftEnd) : base(firstName, lastName, userName, email, salaryPerHour, hoursWorked, shiftStart, shiftEnd)
        {
        }
        public Cleaner()
        {
        }
    }
}
