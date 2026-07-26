using System.ComponentModel.DataAnnotations;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs
{
    public class CreateApplicationUserDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string UserName { get; set; } = null!;

        [Required, EmailAddress,MaxLength(300)]
        public string Email { get; set; } = null!;

        [Phone, MaxLength(30),Required]
        public string PhoneNumber { get; set; }= null!;

        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
    }
}
