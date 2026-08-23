using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO
{
    public abstract class UpdateApplicationUserDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; protected set; }
        [Required, MaxLength(50)]
        public string LastName { get; protected set; }
        [Required, EmailAddress]
        public string Email { get; protected set; }
        [Required, MaxLength(50)]
        public string UserName { get; protected set; }
        [Required, MaxLength(30)]
        public string PhoneNumber { get; protected set; }
        public UpdateApplicationUserDto(string firstName, string lastName, string email, string userName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            PhoneNumber = phoneNumber;
        }



    }
}
