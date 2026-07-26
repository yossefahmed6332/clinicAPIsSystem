using clinicAPIsSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs
{
    public class UpdateApplicationUserDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string UserName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
    }
}
