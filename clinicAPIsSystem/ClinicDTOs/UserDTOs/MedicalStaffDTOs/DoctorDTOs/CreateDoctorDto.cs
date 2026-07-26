using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs
{
    public class CreateDoctorDto:CreateMedicalStaffDto
    {
        [Required,Range(1,int.MaxValue)]
        public int SpecializationId { get; set; }

    }
}
