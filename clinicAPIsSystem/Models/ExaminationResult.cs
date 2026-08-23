using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class ExaminationResult
    {
        public int Id { get; private set; } 
        public string? TestType { get; private set; } 
        public string? ResultValue { get; private set; } 
        public string? unit { get; private set; } 
        public string? NormalRange { get; private set; }
        public string? Notes { get; private set; }
        public DateTime RecordedAt {  get; private set; }
        public Nurse? Nurse { get; private set; } 
        public int NurseId { get; private set; } 
        public MedicalRecord? MedicalRecord { get; private set; } 
        public int MedicalRecordId { get;private set; }
        public ExaminationResult(string testType, string resultValue, string unit, string normalRange, string notes, DateTime recordedAt, int nurseId, int medicalRecordId)
        {
            TestType = testType;
            ResultValue = resultValue;
            this.unit = unit;
            NormalRange = normalRange;
            Notes = notes;
            RecordedAt = recordedAt;
            NurseId = nurseId;
            MedicalRecordId = medicalRecordId;
        }   

        public ExaminationResult()
        {
        }

    }
}
