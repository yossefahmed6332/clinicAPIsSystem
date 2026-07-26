using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using System.ComponentModel.DataAnnotations;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.AccountantDTOs
{
    public class CreateAccountantDto:CreateEmployeeDto
    {
        [Required]
        public string LicenseNumber { get; set; } = null!;
        [Required]
        public int YearsOfExperience { get; set; }


    }
}
