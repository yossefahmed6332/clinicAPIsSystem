namespace clinicAPIsSystem.DTOs.AuthDTO
{
    public class AuthDto
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public AuthDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
