using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;
namespace clinicAPIsSystem.DTOs.UserDTOs.PatientDTO
{
    public class PatientDto: ApplicationUserDto
    {
        public PatientDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber)
            : base(id, userName, email, firstName, lastName, phoneNumber)
        {
        }
    }
    
    }

