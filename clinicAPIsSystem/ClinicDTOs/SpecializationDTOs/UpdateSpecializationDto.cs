using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.SpecializationDTOs
{
    public class UpdateSpecializationDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(300)]
        public string Description { get; set; } = null!;
    }
}
