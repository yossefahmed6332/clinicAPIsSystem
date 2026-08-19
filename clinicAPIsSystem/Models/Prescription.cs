using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class Prescription
    {
        public int Id { get; set; } 
        public string MedicalName { get; set; } = null!;
        public string Dosage { get; set; } = null!; 
        public string Frequency { get; set; } = null!; 
        public string Duration { get; set; } = null!; 
        public string? Instructions { get; set; } 
        public string Diagnosis { get; set; } = null!;
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; } = null!; 
        public int DoctorId { get; set; } 
        public Patient Patient { get; set; } = null!; 
        public int PatientId { get; set; } 
        public MedicalRecord MedicalRecord { get; set; } = null!; 
        public int MedicalRecordId { get; set; } 



    }
}
