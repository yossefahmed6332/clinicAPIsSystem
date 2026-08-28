using clinicAPIsSystem.IRepositoryService.IUserRepository.IEmployeeRepository;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices;
using AutoMapper;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.CleanerDTO;
using clinicAPIsSystem.Models.User.Employee;

namespace clinicAPIsSystem.Services.UserServices.EmployeeServices
{
    public class CleanerService:ICleanerService
    {
        private readonly ICleanerRepository _cleanerRepository; 
        private readonly IUserService _userService; 
        private readonly IMapper _mapper;

        public CleanerService(ICleanerRepository cleanerRepository, IUserService userService, IMapper mapper)
        {
            _cleanerRepository = cleanerRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<CleanerDto> CreateCleanerAsync(CreateCleanerDto createCleanerDto,string password)
        { 
            await _userService.ValidateUserCreation(createCleanerDto.Email, createCleanerDto.UserName, createCleanerDto.PhoneNumber);


            var cleaner = new Cleaner(createCleanerDto.FirstName,
                createCleanerDto.LastName,
                createCleanerDto.UserName,
                createCleanerDto.Email,
                createCleanerDto.PhoneNumber,
                createCleanerDto.SalaryPerHour,
                createCleanerDto.HoursWorked,
                createCleanerDto.ShiftStart,
                createCleanerDto.ShiftEnd
                );

            var createdCleaner = await _cleanerRepository.CreateCleanerAsync(cleaner,password);
            if (!(createdCleaner.addUserRes &&
                  createdCleaner.addPasswordRes &&
                  createdCleaner.addRoleRes))
            {
                if (createdCleaner.addUserRes)
                {
                    await _userService.DeleteUserAsync(
                        createdCleaner.cleaner.Id);
                }

                throw new Exception("Cannot create user, try again");
            }

            return _mapper.Map<CleanerDto>(createdCleaner.cleaner);
        }

        public async Task<List<CleanerDto>> GetAllCleanersAsync()
        {
            var cleaners = await _cleanerRepository.GetAllCleanersAsync();
            return _mapper.Map<List<CleanerDto>>(cleaners);
        }

        public async Task<CleanerDto> GetCleanerAsync(int cleanerId)
        {
            var cleaner = await _cleanerRepository.GetCleanerAsync(cleanerId);
            if (cleaner == null)
            {
                throw new Exception("Cleaner not found");
            }
            return _mapper.Map<CleanerDto>(cleaner);
        }

        public async Task<CleanerDto> UpdateCleanerAsync(
            UpdateCleanerDto updateCleanerDto,
            int id)
        {
            await _userService.ValidateUserCreation(
                updateCleanerDto.Email,
                updateCleanerDto.UserName,
                updateCleanerDto.PhoneNumber);

            var cleaner = await _cleanerRepository.GetCleanerAsync(id);

            if (cleaner == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find cleaner with id {id}");
            }

            cleaner.UpdateCleanerInfo(
                updateCleanerDto.FirstName,
                updateCleanerDto.LastName,
                updateCleanerDto.UserName,
                updateCleanerDto.Email,
                updateCleanerDto.PhoneNumber,
                updateCleanerDto.SalaryPerHour,
                updateCleanerDto.HoursWorked,
                updateCleanerDto.ShiftStart,
                updateCleanerDto.ShiftEnd
            );

            var updatedCleaner =
                await _cleanerRepository.UpdateCleanerAsync(cleaner);

            return _mapper.Map<CleanerDto>(updatedCleaner);
        }

    }
}
