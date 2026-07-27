using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.AuthDTOs
{
    public class LoginDto
    {
        [Required,MaxLength(100)]
        public string Email { set; get; } = null!;
        [Required, MaxLength(300)]
        public string Password { set; get; } = null!;
    }
}
