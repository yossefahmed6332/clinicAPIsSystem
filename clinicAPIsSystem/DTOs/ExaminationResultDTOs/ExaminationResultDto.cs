namespace clinicAPIsSystem.DTOs.ExaminationResultDTOs
{
    public class ExaminationResultDto
    {
        public int Id { get; private set; }
        public string TestType { get; private set; }
        public string ResultValue { get; private set; }
        public string Unit { get; private set; }
        public string NormalRange { get; private set; }
        public string Note { get; private set; }
        public DateTime RecordedAt { get; private set; } 
        public int PatientId { get; private set; }
        public int NurseId { get; private set; }

        public ExaminationResultDto(int id, string testType, string resultValue, string unit, string normalRange, string note, DateTime recordedAt, int patientId, int nurseId)
        {
            Id = id;
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

