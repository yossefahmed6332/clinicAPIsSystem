using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.AuthDTO
{
    public class LoginDto   
    {
        [Required,EmailAddress]
        public string Email { get; private set; }
        [Required, MinLength(6)]
        public string Password { get; private set; }
        public AuthDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
