namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees
{
    public class EmployeeDto : ApplicationUserDTO
    {
        public decimal SalaryPerHour { get; private set; }
        public int HoursWorked { get; private set; }
        public TimeOnly ShiftStart { get; private set; }
        public TimeOnly ShiftEnd { get; private set; }

        public EmployeeDto(
            int id,
            string userName,
            string email,
            string firstName,
            string lastName,
            string phoneNumber,
            decimal salaryPerHour,
            int hoursWorked,
            TimeOnly shiftStart,
            TimeOnly shiftEnd)
            : base(id, userName, email, firstName, lastName, phoneNumber)
        {
            SalaryPerHour = salaryPerHour;
            HoursWorked = hoursWorked;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
        }
    }
}