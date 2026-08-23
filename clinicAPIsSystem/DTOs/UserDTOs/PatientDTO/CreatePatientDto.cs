using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;

namespace clinicAPIsSystem.DTOs.UserDTOs.PatientDTO
{
    public class CreatePatientDto:CreateApplicationUserDto
    {
        public CreatePatientDto(string firstName, string lastName, string email, string userName, string phoneNumber)
            : base(firstName, lastName, email, userName, phoneNumber)
        {
        }
    
    }
}
