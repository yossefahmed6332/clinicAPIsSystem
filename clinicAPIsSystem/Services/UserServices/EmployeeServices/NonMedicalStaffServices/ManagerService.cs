using AutoMapper;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ManagerDTO;
using clinicAPIsSystem.IRepositoryService.IUserRepository.IEmployeeRepository.INonMedicalStaffRepository;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.NonMedicalStaffServices;
using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.Services.UserServices.EmployeeServices.NonMedicalStaffServices
{
    public class ManagerService:IManagerService
    {
        private readonly IMapper _mapper; 
        private readonly IUserService _userService; 
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IMapper mapper, IUserService userService, IManagerRepository managerRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _managerRepository = managerRepository;
        }
        public async Task<ManagerDto> CreateManagerAsync(CreateManagerDto createManagerDto)
        {
            await _userService.ValidateUserCreation(createManagerDto.Email, createManagerDto.UserName, createManagerDto.PhoneNumber);
            var manager = new Manager(
                createManagerDto.FirstName,
                createManagerDto.LastName,
                createManagerDto.UserName,
                createManagerDto.Email,
                createManagerDto.PhoneNumber,
                createManagerDto.SalaryPerHour,
                createManagerDto.HoursWorked,
                createManagerDto.ShiftStart,
                createManagerDto.ShiftEnd,
                createManagerDto.Degree,
                createManagerDto.University,
                createManagerDto.YearsOfExperience,
                createManagerDto.GraduationYear,
                createManagerDto.License
            );

            var managerCreated = await _managerRepository.CreateManagerAsync(manager, createManagerDto.Password);
            if (!(managerCreated.addUserRes &&
                  managerCreated.addPasswordRes &&
                  managerCreated.addRoleRes))
            {
                if (managerCreated.addUserRes)
                {
                    await _userService.DeleteUserAsync(managerCreated.manager.Id);
                }
                throw new Exception("Cannot create user, try again");
            }

            return _mapper.Map<ManagerDto>(managerCreated.manager);
        }

        public async Task<List<ManagerDto>> GetAllManagersAsync()
        {
            var managers = await _managerRepository.GetAllManagersAsync();
            return _mapper.Map<List<ManagerDto>>(managers);
        }
        public async Task<ManagerDto> GetManagerAsync(int id)
        {
            var manager = await _managerRepository.GetManagerAsync(id);
            if (manager == null)
            {
                throw new KeyNotFoundException($"Cannot find user with ID{id}");
            }
            return _mapper.Map<ManagerDto>(manager);
        }

        public async Task<ManagerDto> UpdateManagerAsync (UpdateManagerDto updateManager,int id)
        {
            await _userService.ValidateUserCreation(updateManager.Email,
                updateManager.UserName,
                updateManager.PhoneNumber);
            var manager = await _managerRepository.GetManagerAsync(id);  
            if (manager== null)
            {
                throw new KeyNotFoundException($"User with ID{id} not found"); 
            }

            var updatedManager = await _managerRepository.UpdateManagerAsync(manager);

            return _mapper.Map<ManagerDto> (updatedManager);

           

        }

    }
}
