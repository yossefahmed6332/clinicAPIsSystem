using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.PrescriptionDTOs
{
    public class UpdatePrescriptionDto
    {
        [Required, MaxLength(100)]
        public string? MedicalName { get;  set; }
        [Required, MaxLength(100)]
        public string? Dosage { get;  set; }
        [Required, MaxLength(100)]
        public string? Frequency { get;  set; }
        [Required, MaxLength(100)]
        public string ?Duration { get;  set; }
        [Required, MaxLength(500)]
        public string? Instructions { get;  set; }
        [Required, MaxLength(100)]
        public string? Diagnosis { get;  set; }
        public int DoctorId { get;  set; }
        public int PatientId { get;  set; }



    }
}
