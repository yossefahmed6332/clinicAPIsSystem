using AutoMapper;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.AccountantDTO;
using clinicAPIsSystem.IRepositoryService.IUserRepository.IEmployeeRepository.INonMedicalStaffRepository;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.NonMedicalStaffServices;
using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.Services.UserServices.EmployeeServices.NonMedicalStaffServices
{
    public class AccountantService : IAccountantService
    {
        private readonly IAccountantRepository _accountantRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountantService(
            IAccountantRepository accountantRepository,
            IUserService userService,
            IMapper mapper)
        {
            _accountantRepository = accountantRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<AccountantDto> CreateAccountantAsync(
            CreateAccountantDto createAccountantDto,
            string password)
        {
            await _userService.ValidateUserCreation(
                createAccountantDto.Email,
                createAccountantDto.UserName,
                createAccountantDto.PhoneNumber);

            var accountant = new Accountant(
                createAccountantDto.FirstName,
                createAccountantDto.LastName,
                createAccountantDto.UserName,
                createAccountantDto.Email,
                createAccountantDto.PhoneNumber,
                createAccountantDto.SalaryPerHour,
                createAccountantDto.HoursWorked,
                createAccountantDto.ShiftStart,
                createAccountantDto.ShiftEnd,
                createAccountantDto.Degree,
                createAccountantDto.University,
                createAccountantDto.YearsOfExperience,
                createAccountantDto.GraduationYear,
                createAccountantDto.License
            );

            var accountantCreated =
                await _accountantRepository.CreateAccountantAsync(
                    accountant,
                    password);

            if (!(accountantCreated.addUserRes &&
                  accountantCreated.addPasswordRes &&
                  accountantCreated.addRoleRes))
            {
                if (accountantCreated.addUserRes)
                {
                    await _userService.DeleteUserAsync(
                        accountantCreated.accountant.Id);
                }

                throw new Exception(
                    "Cannot create user, try again");
            }

            return _mapper.Map<AccountantDto>(
                accountantCreated.accountant);
        }

        public async Task<List<AccountantDto>> GetAllAccountsAsync()
        {
            var accountants =
                await _accountantRepository.GetAllAccountantsAsync();

            return _mapper.Map<List<AccountantDto>>(accountants);
        }

        public async Task<AccountantDto> GetAccountantAsync(int id)
        {
            var accountant =
                await _accountantRepository.GetAccountantAsync(id);

            if (accountant == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find accountant with id {id}");
            }

            return _mapper.Map<AccountantDto>(accountant);
        }

        public async Task<AccountantDto> UpdateAccountantAsync(
            UpdateAccountantDto updateAccountantDto,
            int id)
        {
            await _userService.ValidateUserCreation(
                updateAccountantDto.Email,
                updateAccountantDto.UserName,
                updateAccountantDto.PhoneNumber);

            var accountant =
                await _accountantRepository.GetAccountantAsync(id);

            if (accountant == null)
            {
                throw new KeyNotFoundException(
                    $"Cannot find accountant with id {id}");
            }

            accountant.UpdateAccountantInfo(
                updateAccountantDto.FirstName,
                updateAccountantDto.LastName,
                updateAccountantDto.UserName,
                updateAccountantDto.Email,
                updateAccountantDto.PhoneNumber,
                updateAccountantDto.SalaryPerHour,
                updateAccountantDto.HoursWorked,
                updateAccountantDto.ShiftStart,
                updateAccountantDto.ShiftEnd,
                updateAccountantDto.Degree,
                updateAccountantDto.University,
                updateAccountantDto.YearsOfExperience,
                updateAccountantDto.GraduationYear,
                updateAccountantDto.License
            );

            var updatedAccountant =
                await _accountantRepository.UpdateAccountantAsync(
                    accountant);

            return _mapper.Map<AccountantDto>(updatedAccountant);
        }
    }
}