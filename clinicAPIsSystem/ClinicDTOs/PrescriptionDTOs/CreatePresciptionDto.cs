

using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.PrescriptionDTOs
{
    public class CreatePresciptionDto
    {
        [Required, MaxLength(100)]
        public string Diagnosis { get; set; } = null!;
        [Required, Range(1, int.MaxValue)]
        public int DoctorId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int PatientId { get; set; }


    }
}
