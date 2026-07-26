using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.CleanerDTOs;

namespace clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService
{
    public interface ICleanerService
    {
        //method for create cleaner 
        public Task CreateCleanerAsync(CreateCleanerDto dto);
        //method for getting cleaner information
        public Task<CleanerDto> GetCleanerByIdAsync(int id);
        public Task<IEnumerable<CleanerDto>> GetCleanerByCleaningAreasAsync(decimal salary);
        //method for updating cleaner information
        public Task UpdateCleanerSalaryAsync(int cleanerId, decimal newSalary);
        //method for deleting cleaner 
        public Task DeleteCleanerAsync(int cleanerId);


    }
}
