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
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeService (ClinicDbContext clinicDbContext, UserManager<ApplicationUser> userManager)
        {
            _clinicDbContext = clinicDbContext;
            _userManager = userManager;
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
                    Email=employee.Email!, 
                    PhoneNumber=employee.PhoneNumber!,
                    UserName=employee.UserName!,
                    SalaryPerHour=employee.SalaryPerHour,
                    HoursWorked=employee.HoursWorked, 
                    ShiftEnd=employee.ShiftEnd,
                    ShiftStart=employee.ShiftStart,

                };

                dtos.Add(dto);
            }
            return dtos; 
        }
        //create methods
        public async Task CreateReceptionistAsync(CreateEmployeeDto dto)
        {
            bool emailExists= await _userManager.FindByEmailAsync(dto.Email) != null;
            if (emailExists)
            {
                throw new Exception("Email already exists.");
            }
            bool usernameExists =await _userManager.FindByNameAsync(dto.UserName) != null;
            if (usernameExists)
            {
                throw new Exception("Username already exists.");
            }
            bool phoneNumberExists = await _clinicDbContext.Set<Employee>().AnyAsync(e => e.PhoneNumber == dto.PhoneNumber);
            if (phoneNumberExists)
            {

                throw new Exception("Phone number already exists.");
            }

            var receptionist = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.UserName,
                SalaryPerHour = dto.SalaryPerHour,
                HoursWorked = dto.HoursWorked,
                ShiftStart = dto.ShiftStart,
                ShiftEnd = dto.ShiftEnd
            };

            var result = await _userManager.CreateAsync(receptionist, dto.Password);
            var receptionistRoleResult = await _userManager.AddToRoleAsync(receptionist, Roles.Receptionist.ToString());

            if (!receptionistRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign roles.");
            }


        }

        public async Task CreateAdminAsync(CreateEmployeeDto dto)
        {
            bool emailExists = await _userManager.FindByEmailAsync(dto.Email) != null;
            if (emailExists)
            {
                throw new Exception("Email already exists.");
            }
            bool usernameExists = await _userManager.FindByNameAsync(dto.UserName) != null;
            if (usernameExists)
            {
                throw new Exception("Username already exists.");
            }
            bool phoneNumberExists = await _clinicDbContext.Set<Employee>().AnyAsync(e => e.PhoneNumber == dto.PhoneNumber);
            if (phoneNumberExists)
            {

                throw new Exception("Phone number already exists.");
            }

            var receptionist = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.UserName,
                SalaryPerHour = dto.SalaryPerHour,
                HoursWorked = dto.HoursWorked,
                ShiftStart = dto.ShiftStart,
                ShiftEnd = dto.ShiftEnd
            };

            var result = await _userManager.CreateAsync(receptionist, dto.Password);
            var receptionistRoleResult = await _userManager.AddToRoleAsync(receptionist, Roles.Admin.ToString());

            if (!receptionistRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign roles.");
            }

        }

        //Read

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

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByHoursWorkedAsync(int hoursWorked)
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
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByStartShiftAsync(TimeOnly shiftStart)
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