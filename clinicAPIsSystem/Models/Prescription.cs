using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;
using Microsoft.Identity.Client;

namespace clinicAPIsSystem.Models
{
    public class Prescription
    {
        public int Id { get; set; } 
        public string? MedicalName { get; set; } 
        public string? Dosage { get; set; }  
        public string? Frequency { get; set; }  
        public string ?Duration { get; set; }  
        public string? Instructions { get; set; } 
        public string ?Diagnosis { get; set; } 
        public DateTime Date { get; set; }
        public Doctor? Doctor { get; set; }  
        public int DoctorId { get; set; } 
        public MedicalRecord? MedicalRecord { get; set; }  
        public int MedicalRecordId { get; set; } 

        public Prescription(string medicalName, string dosage, string frequency, string duration, string instructions, string diagnosis, DateTime date, int doctorId, int medicalRecordId)
        {
            MedicalName = medicalName;
            Dosage = dosage;
            Frequency = frequency;
            Duration = duration;
            Instructions = instructions;
            Diagnosis = diagnosis;
            Date = date;
            DoctorId = doctorId;
            MedicalRecordId = medicalRecordId;
        }  
        public Prescription()
        {
        }



    }
}
