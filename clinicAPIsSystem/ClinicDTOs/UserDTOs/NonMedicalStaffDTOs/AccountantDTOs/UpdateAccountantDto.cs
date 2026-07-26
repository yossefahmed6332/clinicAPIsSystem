using System.ComponentModel.DataAnnotations;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.AccountantDTOs
{
    public class UpdateAccountantDto: UpdateEmployeeDto
    {
        [Required]
        public string LicenseNumber { get; set; } = null!;
        [Required]
        public int YearsOfExperience { get; set; }

    }
}
