using clinicAPIsSystem.DTOs.AppointmentDTOs;
using clinicAPIsSystem.DTOs.UserDTOs.PatientDTO;

namespace clinicAPIsSystem.IServices.IUserServices
{
    public interface IPatientService
    {
        public Task<PatientDto> CreatePatientAsync(
            CreatePatientDto createPatientDto,
            string password);
        public Task<List<PatientDto>> GetAllPatientsAsync();
        public Task<PatientDto?> GetPatientAsync(int id);
        public Task<PatientDto> UpdatePatientAsync(UpdatePatientDto updatePatientDto,int id);
        public Task DeletePatientAsync(int id);
    }
}
