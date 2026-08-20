using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.UserDTO.ApplicationUserDTOs
{
    public abstract class UpdateApplicationUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [Required, MaxLength(50)]
        public string SecondName { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;
        [Required, MaxLength(30)]
        public string PhoneNumber { get; set; } = null!;
        [Required, MaxLength(50)]
        public string UserName { get; set; } = null!;
    }
}
