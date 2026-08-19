using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class ExaminationResult
    {
        public int Id { get; set; } 
        public string TestType { get; set; } = null!; 
        public string ResultValue { get; set; } = null!;
        public string unit { get; set; } = null!; 
        public string NormalRange { get; set; } = null!; 
        public string Notes { get; set; }=null!;
        public DateTime RecordedAt {  get; set; }
        public Nurse Nurse { get; set; } = null!;
        public int NurseId { get; set; } 
        public Patient Patient { get; set; } = null!; 
        public int PatientId { get; set; } 
        public MedicalRecord MedicalRecord { get; set; } = null!;
        public int MedicalRecordId { get;set; }

    }
}
