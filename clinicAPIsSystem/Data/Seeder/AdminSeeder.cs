using clinicAPIsSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace clinicAPIsSystem.Data.Seeder
{
    public  class AdminSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminSeeder(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
             string email = "admin@clinic.com";

            var admin = await _userManager.FindByEmailAsync(email);

            if (admin != null)
                return;

            admin = new ApplicationUser
            {
                UserName = "admin",
                Email = email,
                FirstName = "System",
                LastName = "Administrator",
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(admin, "Admin@123");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }



    }
}
