using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.PrescriptionDTOs
{
    public class UpdatePrescriptionDto
    {
        [Required, MaxLength(100)]
        public string MedicalName { get; private set; }
        [Required, MaxLength(100)]
        public string Dosage { get; private set; }
        [Required, MaxLength(100)]
        public string Frequency { get; private set; }
        [Required, MaxLength(100)]
        public string Duration { get; private set; }
        [Required, MaxLength(500)]
        public string Instructions { get; private set; }
        [Required, MaxLength(100)]
        public string Diagnosis { get; private set; }
        public int DoctorId { get; private set; }
        public int PatientId { get; private set; }

        public UpdatePrescriptionDto(string medicalName, string dosage, string frequency, string duration, string instructions, string diagnosis, int doctorId, int patientId)
        {
            MedicalName = medicalName;
            Dosage = dosage;
            Frequency = frequency;
            Duration = duration;
            Instructions = instructions;
            Diagnosis = diagnosis;
            DoctorId = doctorId;
            PatientId = patientId;
        }


    }
}
