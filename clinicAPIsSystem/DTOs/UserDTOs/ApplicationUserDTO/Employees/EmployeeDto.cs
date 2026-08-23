namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees
{
    public abstract class EmployeeDto: ApplicationUserDto
    {
        public decimal SalaryPerHour { get; protected set; }
        public int HoursWorked { get; protected set; }
        public TimeOnly ShiftStart { get; protected set; }
        public TimeOnly ShiftEnd { get; protected set; }
        public EmployeeDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd)
            : base(id, userName, email, firstName, lastName, phoneNumber)
        {
            SalaryPerHour = salaryPerHour;
            HoursWorked = hoursWorked;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
        }
    {
    }
}
