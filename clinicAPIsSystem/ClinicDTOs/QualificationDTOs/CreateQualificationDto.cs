using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.QualificationDTOs
{
    public class CreateQualificationDto
    {
        [Required,MaxLength(100)]
        public string Degree { get; set; } = null!;
        [Required,MaxLength(100)]
        public string University { get; set; } = null!;

    }
}
