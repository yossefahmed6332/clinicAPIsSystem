using Microsoft.AspNetCore.Identity;
namespace clinicAPIsSystem.Models.User
{
    public abstract class ApplicationUser:IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;


    }
}
