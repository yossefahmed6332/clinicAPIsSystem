using clinicAPIsSystem.DTOs.AuthDTO;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace clinicAPIsSystem.Services.AuthServices
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _signInManager.UserManager
                .FindByEmailAsync(dto.Email);

            if (user == null)
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                dto.Password,
                lockoutOnFailure: true);

            if (!result.Succeeded)
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");

            return await GenerateJwtTokenAsync(user);
        }

        public async Task<string> GenerateJwtTokenAsync(
            ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(
                    JwtRegisteredClaimNames.Sub,
                    user.Id.ToString()),

                new Claim(
                    JwtRegisteredClaimNames.UniqueName,
                    user.UserName!),

                new Claim(
                    JwtRegisteredClaimNames.Email,
                    user.Email!),

                new Claim(
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["JWT:Key"]!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(
                        _configuration["JWT:ExpireMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}