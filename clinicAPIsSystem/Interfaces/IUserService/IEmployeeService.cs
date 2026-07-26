using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
namespace clinicAPIsSystem.Interfaces.IUserService
{
    public interface IEmployeeService
    {
        //method for create employee 
        public Task CreateEmployeeAsync(CreateEmployeeDto employeeDto);//don't call it in controller call it in NonMedicalStaffService & MedicalStaffService  

        //methhod for getting employee information 
        public Task<IEnumerable<EmployeeDto>> GetEmployeeBySalaryAsync(decimal salary); 
        public Task<IEnumerable<EmployeeDto>> GetEmployeeByHoursWorked(int hoursWorked);
        public Task<IEnumerable<EmployeeDto>> GetEmployeeByStartShiftAsync(TimeOnly startShift);
        public Task<IEnumerable<EmployeeDto>>  GetEmployeesByShiftEndAsync(TimeOnly endShift);

        //method for updating employee Data 
        public Task UpdateSalaryPerHourAsync(int employeeId, decimal newSalaryPerHour); 
        public Task UpdateHoursWorkedAsync(int employeeId, decimal newHoursWorked);
        public Task UpdateShiftStartAsync(int employeeId, TimeOnly newShiftStart);
        public Task UpdateShiftEndAsync(int employeeId, TimeOnly newShiftEnd);
        



    }
}
