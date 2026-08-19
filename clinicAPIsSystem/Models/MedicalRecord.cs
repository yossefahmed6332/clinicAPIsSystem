using clinicAPIsSystem.Models.User;

namespace clinicAPIsSystem.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; } 
        public decimal Height { get; set; }
        public decimal Weight { get; set; } 
        public string BloodType { get; set; } = null!; 
        public Patient Patient { get; set; } = null!;
        public int PatientId { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public ICollection<ExaminationResult> ExaminationResults { get; set; } = new HashSet<ExaminationResult>();
        public ICollection<VitalSigns> VitalSigns { get; set; } = new HashSet<VitalSigns>();
    }
}
