using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using System.ComponentModel.DataAnnotations;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.CleanerDTOs
{
    public class UpdateCleanerDto:UpdateEmployeeDto
    {
        [Required]
        public string CleaningArea { get; set; } = null!;
    }
}
