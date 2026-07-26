using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.MedicalDTOs
{
    public class UpdateMedicalDto
    {

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(100)]
        public string TakeTime { get; set; } = null!;
    }
}
