using AutoMapper;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ReceptionistDTO;
using clinicAPIsSystem.IRepositoryService.IUserRepository.IEmployeeRepository.INonMedicalStaffRepository;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;


using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.NonMedicalStaffServices;
namespace clinicAPIsSystem.Services.UserServices.EmployeeServices.NonMedicalStaffServices
{
    public class ReceptionistService : IReceptionistService
    {
        private readonly IReceptionistRepository _receptionistRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ReceptionistService(
            IReceptionistRepository receptionistRepository,
            IUserService userService,
            IMapper mapper)
        {
            _receptionistRepository = receptionistRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ReceptionistDto> CreateReceptionistAsync(
            CreateReceptionistDto createReceptionistDto,
            string password)
        {
            await _userService.ValidateUserCreation(
                createReceptionistDto.Email,
                createReceptionistDto.UserName,
                createReceptionistDto.PhoneNumber);

            var receptionist = new Receptionist(
                createReceptionistDto.FirstName,
                createReceptionistDto.LastName,
                createReceptionistDto.UserName,
                createReceptionistDto.Email,
                createReceptionistDto.PhoneNumber,
                createReceptionistDto.SalaryPerHour,
                createReceptionistDto.HoursWorked,
                createReceptionistDto.ShiftStart,
                createReceptionistDto.ShiftEnd,
                createReceptionistDto.Degree,
                createReceptionistDto.University,
                createReceptionistDto.YearsOfExperience,
                createReceptionistDto.GraduationYear,
                createReceptionistDto.License
            );

            var receptionistCreated =
                await _receptionistRepository.CreateReceptionistAsync(
                    receptionist,
                    password);

            if (!(receptionistCreated.addUserRes &&
                  receptionistCreated.addPasswordRes &&
                  receptionistCreated.addRoleRes))
            {
                if (receptionistCreated.addUserRes)
                {
                    await _userService.DeleteUserAsync(
                        receptionistCreated.receptionist.Id);
                }

                throw new Exception(
                    "Cannot create user, try again");
            }

            return _mapper.Map<ReceptionistDto>(
                receptionistCreated.receptionist);
        }

        public async Task<ReceptionistDto> GetReceptionistAsync(int id)
        {
            var receptionist =
                await _receptionistRepository.GetReceptionistAsync(id);

            if (receptionist == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find receptionist with id {id}");
            }

            return _mapper.Map<ReceptionistDto>(receptionist);
        }

        public async Task<List<ReceptionistDto>> GetAllReceptionistsAsync()
        {
            var receptionists =
                await _receptionistRepository.GetAllReceptionistsAsync();

            return _mapper.Map<List<ReceptionistDto>>(receptionists);
        }

        public async Task<ReceptionistDto> UpdateReceptionistAsync(
            UpdateReceptionistDto updateReceptionistDto,
            int id)
        {
            await _userService.ValidateUserCreation(
                updateReceptionistDto.Email,
                updateReceptionistDto.UserName,
                updateReceptionistDto.PhoneNumber);

            var receptionist =
                await _receptionistRepository.GetReceptionistAsync(id);

            if (receptionist == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find receptionist with id {id}");
            }

            receptionist.UpdateReceptionistInfo(
                updateReceptionistDto.FirstName,
                updateReceptionistDto.LastName,
                updateReceptionistDto.UserName,
                updateReceptionistDto.Email,
                updateReceptionistDto.PhoneNumber,
                updateReceptionistDto.SalaryPerHour,
                updateReceptionistDto.HoursWorked,
                updateReceptionistDto.ShiftStart,
                updateReceptionistDto.ShiftEnd,
                updateReceptionistDto.Degree,
                updateReceptionistDto.University,
                updateReceptionistDto.YearsOfExperience,
                updateReceptionistDto.GraduationYear,
                updateReceptionistDto.License
            );

            var updatedReceptionist =
                await _receptionistRepository.UpdateReceptionistAsync(
                    receptionist);

            return _mapper.Map<ReceptionistDto>(updatedReceptionist);
        }
    }
}