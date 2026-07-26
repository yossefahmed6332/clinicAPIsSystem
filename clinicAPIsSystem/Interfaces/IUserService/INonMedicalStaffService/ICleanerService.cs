using clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.CleanerDTOs;

namespace clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService
{
    public interface ICleanerService
    {
        //method for create cleaner 
        public Task CreateCleanerAsync(CreateCleanerDto dto);
        //method for getting cleaner information
        public Task<CleanerDto> GetCleanerByIdAsync(int id);
        public Task<IEnumerable<CleanerDto>> GetCleanerByCleaningAreasAsync(string CleaningArea);
        //method for updating cleaner information
        public Task UpdateCleanerAsync(int cleanerId, UpdateCleanerDto cleaner);
        //method for deleting cleaner 
        public Task DeleteCleanerAsync(int cleanerId);


    }
}
