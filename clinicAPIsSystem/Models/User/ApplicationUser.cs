using Microsoft.AspNetCore.Identity;
namespace clinicAPIsSystem.Models
{
    public  class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!; 
        public string LastName { get; set; } = null!;
        public Gender Gender; 
    }
}
