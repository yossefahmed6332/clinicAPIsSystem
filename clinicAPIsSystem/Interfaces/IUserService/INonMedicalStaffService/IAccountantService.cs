using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.AccountantDTOs;
namespace clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService
{
    public interface IAccountantService
    {
        //method for create accountant
        public Task CreateAccountantAsync(CreateAccountantDto dto);
        //method for getting accountant information
        public Task<AccountantDto> GetAccountantByIdAsync(int id);
        public Task<AccountantDto> GetAccountantByLicenseAsync(string license);
        //methods for updating accountant information


       


    }
}
