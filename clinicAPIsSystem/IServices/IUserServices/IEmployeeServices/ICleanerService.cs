using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.CleanerDTO;

namespace clinicAPIsSystem.IServices.IUserServices.IEmployeeServices
{
    public interface ICleanerService
    {
        public Task<CleanerDto> CreateCleanerAsync(CreateCleanerDto createCleanerDto,string password); 
        public Task<List<CleanerDto>> GetAllCleanersAsync();
        public Task<CleanerDto> GetCleanerAsync(int id);
        public Task<CleanerDto> UpdateCleanerAsync(UpdateCleanerDto updateCleanerDto, int id);
    }
}
