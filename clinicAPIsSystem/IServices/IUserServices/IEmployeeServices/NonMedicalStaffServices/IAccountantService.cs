using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.AccountantDTO;

namespace clinicAPIsSystem.IServices.IUserServices.IEmployeeServices.NonMedicalStaffServices
{
    public interface IAccountantService
    {
        public Task<AccountantDto> CreateAccountantAsync(CreateAccountantDto createAccountantDto, string password); 
        public Task<List<AccountantDto>> GetAllAccountsAsync();
        public Task<AccountantDto> GetAccountantAsync(int id);
        public Task<AccountantDto> UpdateAccountantAsync(UpdateAccountantDto updateAccountantDto, int id);
    }
}
