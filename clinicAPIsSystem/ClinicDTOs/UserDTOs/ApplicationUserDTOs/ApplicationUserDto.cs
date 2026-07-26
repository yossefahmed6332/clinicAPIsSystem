using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Gender Gender { get; set; }
    }
}
