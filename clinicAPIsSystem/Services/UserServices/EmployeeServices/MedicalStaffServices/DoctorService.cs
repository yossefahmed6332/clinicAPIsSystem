using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.IMedicalStaffServices;
using AutoMapper;
using clinicAPIsSystem.IRepositoryService.IUserRepository.IEmployeeRepository.IMedicalStaffRepository;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.DoctorDTO;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.Services.UserServices.EmployeeServices.MedicalStaffServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public DoctorService(
            IDoctorRepository doctorRepository,
            IMapper mapper,
            IUserService userService)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<DoctorDto> CreateDoctorAsync(
            CreateDoctorDto createDoctorDto,
            string password)
        {
            await _userService.ValidateUserCreation(
                createDoctorDto.Email,
                createDoctorDto.UserName,
                createDoctorDto.PhoneNumber);

            var doctor = new Doctor(
                createDoctorDto.FirstName,
                createDoctorDto.LastName,
                createDoctorDto.UserName,
                createDoctorDto.Email,
                createDoctorDto.PhoneNumber,
                createDoctorDto.SalaryPerHour,
                createDoctorDto.HoursWorked,
                createDoctorDto.ShiftStart,
                createDoctorDto.ShiftEnd,
                createDoctorDto.Degree,
                createDoctorDto.University,
                createDoctorDto.YearsOfExperience,
                createDoctorDto.GraduationYear,
                createDoctorDto.License
            );

            var doctorCreated =
                await _doctorRepository.CreateDoctorAsync(
                    doctor,
                    password);

            if (!(doctorCreated.addUserRes &&
                  doctorCreated.addPasswordRes &&
                  doctorCreated.addRoleRes))
            {
                if (doctorCreated.addUserRes)
                {
                    await _userService.DeleteUserAsync(
                        doctorCreated.doctor.Id);
                }

                throw new Exception(
                    "Cannot create user, try again");
            }

            return _mapper.Map<DoctorDto>(
                doctorCreated.doctor);
        }

        public async Task<DoctorDto> GetDoctorAsync(int id)
        {
            var doctor =
                await _doctorRepository.GetDoctorAsync(id);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find doctor with id {id}");
            }

            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<List<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors =
                await _doctorRepository.GetAllDoctorsAsync();

            return _mapper.Map<List<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> UpdateDoctorAsync(
            UpdateDoctorDto updateDoctorDto,
            int id)
        {
            await _userService.ValidateUserCreation(
                updateDoctorDto.Email,
                updateDoctorDto.UserName,
                updateDoctorDto.PhoneNumber);

            var doctor =
                await _doctorRepository.GetDoctorAsync(id);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find doctor with id {id}");
            }

            doctor.UpdateDoctorInfo(
                updateDoctorDto.FirstName,
                updateDoctorDto.LastName,
                updateDoctorDto.UserName,
                updateDoctorDto.Email,
                updateDoctorDto.PhoneNumber,
                updateDoctorDto.SalaryPerHour,
                updateDoctorDto.HoursWorked,
                updateDoctorDto.ShiftStart,
                updateDoctorDto.ShiftEnd,
                updateDoctorDto.Degree,
                updateDoctorDto.University,
                updateDoctorDto.YearsOfExperience,
                updateDoctorDto.GraduationYear,
                updateDoctorDto.License
            );

            var updatedDoctor =
                await _doctorRepository.UpdateDoctorAsync(doctor);

            return _mapper.Map<DoctorDto>(updatedDoctor);
        }
    }
}