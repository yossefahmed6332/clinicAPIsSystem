using clinicAPIsSystem.Interfaces.IUserService;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Data;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Numerics;
namespace clinicAPIsSystem.Services.UserService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ClinicDbContext _clinicDbContext; 
        public EmployeeService (ClinicDbContext clinicDbContext)
        {
            _clinicDbContext = clinicDbContext; 
        }

        private async Task<IEnumerable<EmployeeDto>> GetEmployeeDto(List<Employee> employees)
        {

            List<EmployeeDto> dtos = new List<EmployeeDto>();
            foreach (Employee employee in employees)
            {
                var dto = new EmployeeDto
                {
                    FirstName = employee.FirstName,
                    LastName= employee.LastName,
                    Email=employee.Email, 
                    PhoneNumber=employee.PhoneNumber,
                    UserName=employee.UserName,
                    SalaryPerHour=employee.SalaryPerHour,
                    HoursWorked=employee.HoursWorked, 
                    ShiftEnd=employee.ShiftEnd,
                    ShiftStart=employee.ShiftStart,

                };

                dtos.Add(dto);
            }
            return dtos; 
        }


        public async Task<IEnumerable<EmployeeDto>> GetEmployeesBySalaryAsync (decimal salary)
        {
            var employee  = await _clinicDbContext.Set<Employee>()
                .Where(e=>e.SalaryPerHour == salary)
                .ToListAsync();


            if (employee.Count == 0)
            {
                throw new Exception("there is no Employees with this salary");
            }

            var dtos = GetEmployeeDto(employee);

            return dtos.Result; 
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeeByHoursWorked (int hoursWorked)
        {
            var employee = await _clinicDbContext.Set<Employee>()
             .Where(e => e.HoursWorked == hoursWorked)
             .ToListAsync();


            if (employee.Count == 0)
            {
                throw new Exception("there is no Employees with this salary");
            }

            var dtos = GetEmployeeDto(employee);

            return dtos.Result;
        
    }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeByStartShiftAsync(TimeOnly shiftStart)
        {
            var employee = await _clinicDbContext.Set<Employee>()
            .Where(e => e.ShiftStart == shiftStart)
            .ToListAsync();


            if (employee.Count == 0)
            {
                throw new Exception("there is no Employees with this salary");
            }

            var dtos = GetEmployeeDto(employee);

            return dtos.Result;
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByShiftEndAsync(TimeOnly shiftEnd)
        {
            var employee = await _clinicDbContext.Set<Employee>()
           .Where(e => e.ShiftEnd == shiftEnd)
           .ToListAsync();


            if (employee.Count == 0)
            {
                throw new Exception("there is no Employees with this salary");
            }

            var dtos = GetEmployeeDto(employee);

            return dtos.Result;
        }

        //method for updating employee Data 
        public async Task UpdateSalaryPerHourAsync(int employeeId, decimal newSalaryPerHour)
        {
            var employee = await _clinicDbContext.Set<Employee>()
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            employee.SalaryPerHour = newSalaryPerHour;
            await _clinicDbContext.SaveChangesAsync();
        }

        public async Task UpdateHoursWorkedAsync(int employeeId, int newHoursWorked)
        {
            var employee = await _clinicDbContext.Set<Employee>()
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            employee.HoursWorked = newHoursWorked;
            await _clinicDbContext.SaveChangesAsync();
        }

        public async Task UpdateShiftStartAsync(int employeeId, TimeOnly newShiftStart)
        {
            var employee = await _clinicDbContext.Set<Employee>()
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            employee.ShiftStart = newShiftStart;
            await _clinicDbContext.SaveChangesAsync();
        }

        public async Task UpdateShiftEndAsync(int employeeId, TimeOnly newShiftEnd)
        {
            var employee = await _clinicDbContext.Set<Employee>()
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            employee.ShiftEnd = newShiftEnd;
            await _clinicDbContext.SaveChangesAsync();
        }


    }
}