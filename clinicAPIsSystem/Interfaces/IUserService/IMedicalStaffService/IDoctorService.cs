using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs;
namespace clinicAPIsSystem.Interfaces.IUserService.IMedicalStaffService
{
    public interface IDoctorService
    {
        //method for create doctor 
        public Task CreateDoctorAsync(CreateDoctorDto doctorDto); //call it in controller 
        //method for getting doctor information
        public Task<IEnumerable<DoctorDto>> GetDoctorBySpecializationAsync(string specialization);
        //method for updating doctor information 
        public Task UpdateDoctorSpecializationAsync (int doctorId, string newSpecializationName);
        public Task UpdateYearsOfExperienceAsync(int doctorId, int yearsOfExperience);
        public Task UpdateLicenseNumberAsync(int doctorId, string licenseNumber);
    }
}
