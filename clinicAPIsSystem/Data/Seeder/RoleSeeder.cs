using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace clinicAPIsSystem.Data.Seeder
{
    public class RoleSeeder
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RoleSeeder(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            string[] roles =
            {
            Roles.Admin.ToString(),
            Roles.Doctor.ToString(),
            Roles.Nurse.ToString(),
            Roles.Patient.ToString(),
            Roles.Accountant.ToString(),
            Roles.Receptionist.ToString(),
            Roles.Cleaner.ToString()
        };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(role: new IdentityRole<int>(role)); 
                }
            }
        }
    }
}
