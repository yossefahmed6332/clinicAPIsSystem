using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using System.ComponentModel.DataAnnotations;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.CleanerDTOs
{
    public class CreateCleanerDto:CreateEmployeeDto
    {
        [Required]
        public string CleaningArea { get; set; } = null!;
    }
}
