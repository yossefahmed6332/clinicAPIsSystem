using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs
{
    public class UpdateDoctorDto:UpdateMedicalStaffDto
    {
        [Required,MaxLength(50)]
        public int SpecializationId { get; set; } 
    }
}
