using clinicAPIsSystem.ClinicDTOs.UserDTOs.PatientDTOs;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace clinicAPIsSystem.Services
{
    public class AuthService : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;

        }
        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid email or password.");

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                lockoutOnFailure: true
            );

            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid email or password.");

            string token = await GenerateJwtTokenAsync(user);
            if (token == null)
                throw new UnauthorizedAccessException("Failed to Access account , try again later.");

            return token;
        }
        public async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),

    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!),

    new Claim(JwtRegisteredClaimNames.Email, user.Email!),

    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["JWT:ExpireMinutes"])
                ),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RegisterAsUserAsync(CreatePatientDto dto)
        {
            if (await _userManager.Users.AnyAsync(u => u.Email == dto.Email))
                throw new InvalidOperationException("User with this email already exists.");

            if (await _userManager.Users.AnyAsync(u => u.PhoneNumber == dto.PhoneNumber))
                throw new InvalidOperationException("User with this phone number already exists.");

            if (await _userManager.Users.AnyAsync(u => u.UserName == dto.UserName))
                throw new InvalidOperationException("User with this username already exists.");

            var patient = new Patient
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber
            };

            var createResult = await _userManager.CreateAsync(patient, dto.Password);

            if (!createResult.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join(", ", createResult.Errors.Select(e => e.Description)));
            }

            var roleResult = await _userManager.AddToRoleAsync(patient, nameof(Roles.Patient));

            if (!roleResult.Succeeded)
            {
                throw new InvalidOperationException(
                    "Could not assign role to the user: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
            }
        }
    }
}