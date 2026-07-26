using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs
{
    public class UpdateMedicalStaffDto:UpdateEmployeeDto
    {
        [Required]
        public int YearsOfExperience { get; set; }
        [Required, MaxLength(50)]
        public string LicenseNumber { get; set; } = null!;
        [Required]
        public int QualificationId { get; set; }

    }
}
