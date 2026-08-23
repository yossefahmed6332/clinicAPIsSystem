using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;

namespace clinicAPIsSystem.DTOs.UserDTOs.AdminDTO
{
    public class AdminDto:ApplicationUserDto
    {
        public AdminDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber)
            : base(id, userName, email, firstName, lastName, phoneNumber)
        {
        }   
    }
}
