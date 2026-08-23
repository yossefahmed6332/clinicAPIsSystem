using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO
{
    public class CreateApplicationUserDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; private set; }
        [Required, MaxLength(50)]
        public string LastName { get; private set; }
        [Required, EmailAddress]
        public string Email { get; private set; }
        [Required, MaxLength(50)]
        public string UserName { get; private set; }
        [Required, MaxLength(30)]
        public string PhoneNumber { get; private set; } 
        public CreateApplicationUserDto(string firstName, string lastName, string email, string userName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            PhoneNumber = phoneNumber;
        }



    }
}
