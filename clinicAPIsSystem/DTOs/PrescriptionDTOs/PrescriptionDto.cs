using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.PrescriptionDTOs
{
    public class PrescriptionDto
    {
        public int Id { get; private set; }
        public string MedicalName { get; private set; }
        public string Dosage { get; private set; }
        public string Frequency { get; private set; }
        public string Duration { get; private set; }
        public string Instructions { get; private set; }
        public string Diagnosis { get; private set; }
        public int DoctorId { get; private set; }
        public int PatientId { get; private set; }

        public PrescriptionDto(int id, string medicalName, string dosage, string frequency, string duration, string instructions, string diagnosis, int doctorId, int patientId)
        {
            Id = id;
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
