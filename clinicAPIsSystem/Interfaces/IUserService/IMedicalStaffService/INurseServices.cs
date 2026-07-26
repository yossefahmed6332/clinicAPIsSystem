using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.NurseDTOs;
namespace clinicAPIsSystem.Interfaces.IUserService.IMedicalStaffService
{
    public interface INurseServices
    {
        public Task CreateNurseAsync(CreateNurseDto nurseDto);
        //method for updating doctor information 
        public Task UpdateYearsOfExperienceAsync(int nurseId, int yearsOfExperience);
        public Task UpdateLicenseNumberAsync(int nurseId, string licenseNumber);

    }
}
