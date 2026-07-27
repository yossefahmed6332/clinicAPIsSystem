using clinicAPIsSystem.ClinicDTOs.UserDTOs.PatientDTOs;

namespace clinicAPIsSystem.Interfaces.IUserService
{
    public interface IPatientService
    {
        public Task CreatePatientAsync(CreatePatientDto dto);
    }
}
