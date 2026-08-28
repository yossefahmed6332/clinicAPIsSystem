using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.IMedicalStaffServices;
using AutoMapper;
using clinicAPIsSystem.IRepositoryService.IUserRepository.IEmployeeRepository.IMedicalStaffRepository;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.Nurse;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;
namespace clinicAPIsSystem.Services.UserServices.EmployeeServices.MedicalStaffServices

{
    public class NurseService:INurseService
    {
        private readonly INurseRepository _nurseRepository; 
        private readonly IMapper _mapper; 
        private readonly IUserService _userService;
        public NurseService(INurseRepository nurseRepository, IMapper mapper, IUserService userService)
        {
            _nurseRepository = nurseRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<NurseDto> CreateNurseAsync(CreateNurseDto createNurseDto)
        {
            await _userService.ValidateUserCreation(createNurseDto.Email, createNurseDto.UserName, createNurseDto.PhoneNumber);

            var nurse = new Nurse(
                createNurseDto.FirstName,
                createNurseDto.LastName,
                createNurseDto.UserName,
                createNurseDto.Email,
                createNurseDto.PhoneNumber,
                createNurseDto.SalaryPerHour,
                createNurseDto.HoursWorked,
                createNurseDto.ShiftStart,
                createNurseDto.ShiftEnd,
                createNurseDto.Degree,
                createNurseDto.University,
                createNurseDto.YearsOfExperience,
                createNurseDto.GraduationYear,
                createNurseDto.License
                );

            var nurseCreated = await _nurseRepository.CreateNurseAsync(nurse, createNurseDto.Password);

            if (!(nurseCreated.addUserRes &&
                  nurseCreated.addPasswordRes &&
                  nurseCreated.addRoleRes))
            {
                if (nurseCreated.addUserRes)
                {
                    await _userService.DeleteUserAsync(
                        nurseCreated.nurse.Id);
                }

                throw new Exception("Cannot create user, try again");
            }

            return _mapper.Map<NurseDto>(nurseCreated.nurse);
        }

        public async Task<NurseDto> GetNurseAsync(int nurseId)
        {
            var nurse = await _nurseRepository.GetNurseAsync(nurseId);
            if (nurse == null)
            {
                throw new Exception("Nurse not found");
            }
            return _mapper.Map<NurseDto>(nurse);
        }
        public async Task<List<NurseDto>> GetAllNursesAsync()
        {
            var nurses = await _nurseRepository.GetAllNursesAsync();
            return _mapper.Map<List<NurseDto>>(nurses);
        }



        public async Task<NurseDto> UpdateNurseAsync(
            
            UpdateNurseDto updateNurseDto, int id)
        {
            await _userService.ValidateUserCreation(
                updateNurseDto.Email,
                updateNurseDto.UserName,
                updateNurseDto.PhoneNumber);

            var nurse = await _nurseRepository.GetNurseAsync(id);

            if (nurse == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find nurse with id {id}");
            }

            nurse.UpdateNurseInfo(
                updateNurseDto.FirstName,
                updateNurseDto.LastName,
                updateNurseDto.UserName,
                updateNurseDto.Email,
                updateNurseDto.PhoneNumber,
                updateNurseDto.SalaryPerHour,
                updateNurseDto.HoursWorked,
                updateNurseDto.ShiftStart,
                updateNurseDto.ShiftEnd,
                updateNurseDto.Degree,
                updateNurseDto.University,
                updateNurseDto.YearsOfExperience,
                updateNurseDto.GraduationYear,
                updateNurseDto.License
            );

            var updatedNurse =
                await _nurseRepository.UpdateNurseAsync(nurse);

            return _mapper.Map<NurseDto>(updatedNurse);
        }

    }
}
