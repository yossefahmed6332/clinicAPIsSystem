using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class VitalSigns
    {
        public int Id { get; set; } 
        public int BloodPressure { get; set; } 
        public int BloodPressureSystolic { get; set; }
        public int BloodPressureDiastolic { get; set; } 
        public int HeartRate { get; set; } 
        public decimal Temperature { get; set; } 
        public decimal OxygenSaturation { get; set; } 
        public DateTime RecordedAt { get; set; }
        public Nurse Nurse { get; set; } = null!; 
        public int NurseId { get; set; } 
        public Patient Patient { get; set; } = null!; 
        public MedicalRecord MedicalRecord { get; set; } = null!; 
        public int MedicalRecordId {  get; set; }

       
    }
}
