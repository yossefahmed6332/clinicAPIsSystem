using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.PrescriptionDTOs
{
    public class PrescriptionDto
    {
        public int Id { get;  set; }
        public string? MedicalName { get;  set; }
        public string? Dosage { get;  set; }
        public string? Frequency { get;  set; }
        public string? Duration { get;  set; }
        public string? Instructions { get;  set; }
        public string?  Diagnosis { get;  set; }
        public int DoctorId { get;  set; }
        public int PatientId { get;  set; }

    }
}
