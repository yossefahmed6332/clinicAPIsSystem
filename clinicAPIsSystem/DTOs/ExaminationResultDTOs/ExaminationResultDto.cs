namespace clinicAPIsSystem.DTOs.ExaminationResultDTOs
{
    public class ExaminationResultDto
    {
        public int Id { get;  set; }
        public string? TestType { get;  set; }
        public string? ResultValue { get;  set; }
        public string? Unit { get;  set; }
        public string? NormalRange { get;  set; }
        public string? Note { get;  set; }
        public DateTime RecordedAt { get;  set; } 
        public int NurseId { get;  set; }
        public int MedicalRecordId { get;  set; }



    }
    }

