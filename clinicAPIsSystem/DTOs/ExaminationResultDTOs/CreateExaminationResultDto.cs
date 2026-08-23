using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.ExaminationResultDTOs
{
    public class CreateExaminationResultDto
    {
        [Required,MaxLength(500)]
        public string TestType { get; private set; }
        [Required,MaxLength(50)]
        public string ResultValue { get; private set; }
        [Required, MaxLength(50)]
        public string Unit { get; private set; }
        [Required, MaxLength(100)]
        public string NormalRange { get; private set; }
        [Required, MaxLength(1000)]
        public string Note { get; private set; }
        [Required]
        public DateTime RecordedAt { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int PatientId { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int NurseId { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int MedicalRecordId { get; private set; }

        public CreateExaminationResultDto(string testType, string resultValue, string unit, string normalRange, string note, DateTime recordedAt, int patientId, int nurseId, int medicalRecordId)
        {
            TestType = testType;
            ResultValue = resultValue;
            Unit = unit;
            NormalRange = normalRange;
            Note = note;
            RecordedAt = recordedAt;
            PatientId = patientId;
            NurseId = nurseId;
        }
    }
}
