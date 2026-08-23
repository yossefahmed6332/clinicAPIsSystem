using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;

namespace clinicAPIsSystem.DTOs.UserDTOs.AdminDTO
{
    public class UpdateAdminDto : UpdateApplicationUserDto
    {
        public UpdateAdminDto(string firstName, string lastName, string email, string userName, string phoneNumber)
            : base(firstName, lastName, email, userName, phoneNumber)
        {
        }
    }
}
