using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
namespace clinicAPIsSystem.Interfaces.IUserService
{
    public interface IEmployeeService
    {
        //create methods 
        public Task  CreateReceptionistAsync(CreateEmployeeDto dto);
        public Task CreateAdminAsync (CreateEmployeeDto dto);
        //methods for getting employee information 
        public Task<IEnumerable<EmployeeDto>> GetEmployeesBySalaryAsync(decimal salary); 
        public Task<IEnumerable<EmployeeDto>> GetEmployeesByHoursWorkedAsync(int hoursWorked);
        public Task<IEnumerable<EmployeeDto>> GetEmployeesByShiftStartAsync(TimeOnly shiftStart);
        public Task<IEnumerable<EmployeeDto>>  GetEmployeesByShiftEndAsync(TimeOnly shiftEnd);

        //method for updating employee Data 
        public Task UpdateSalaryPerHourAsync(int employeeId, decimal newSalaryPerHour); 
        public Task UpdateHoursWorkedAsync(int employeeId, int newHoursWorked);
        public Task UpdateShiftStartAsync(int employeeId, TimeOnly newShiftStart);
        public Task UpdateShiftEndAsync(int employeeId, TimeOnly newShiftEnd);
        



    }
}
