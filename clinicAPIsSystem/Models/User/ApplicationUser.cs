using Microsoft.AspNetCore.Identity;
namespace clinicAPIsSystem.Models.User
{
    public abstract class ApplicationUser:IdentityUser<int>
    {
        protected string FirstName { get; set; } = null!;
        protected string SecondName { get; set; } = null!;

    }
}
