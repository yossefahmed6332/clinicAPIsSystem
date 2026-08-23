using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;

namespace clinicAPIsSystem.DTOs.UserDTOs.AdminDTO
{
    public class CreateAdminDto:CreateApplicationUserDto
    {
        public CreateAdminDto(string firstName, string lastName, string email, string userName, string phoneNumber)
            : base(firstName, lastName, email, userName, phoneNumber)
        {
        }
    }
}
