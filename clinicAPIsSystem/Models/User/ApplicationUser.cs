using Microsoft.AspNetCore.Identity;
namespace clinicAPIsSystem.Models
{
    public abstract class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!; 
        public string LastName { get; set; } = null!;
        public Gender gender; 
    }
}
