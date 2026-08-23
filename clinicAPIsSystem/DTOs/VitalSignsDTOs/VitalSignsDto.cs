namespace clinicAPIsSystem.DTOs.VitalSignsDTOs
{
    public class VitalSignsDto
    {
        public int Id { get; private set; }
        public int BloodPressureSystolic { get; private set; }
        public int BloodPressureDiastolic { get; private set; }
        public int HeartRate { get; private set; }
        public decimal Temperature { get; private set; }
        public decimal OxygenSaturation { get; private set; }
        public DateTime RecordedAt { get; private set; }
        public int NurseId { get; private set; }
        public int PatientId { get; private set; }

        public VitalSignsDto(int id, int bloodPressureSystolic, int bloodPressureDiastolic, int heartRate, decimal temperature, decimal oxygenSaturation, DateTime recordedAt, int nurseId, int patientId)
        {
            Id = id;
            BloodPressureSystolic = bloodPressureSystolic;
            BloodPressureDiastolic = bloodPressureDiastolic;
            HeartRate = heartRate;
            Temperature = temperature;
            OxygenSaturation = oxygenSaturation;
            RecordedAt = recordedAt;
            NurseId = nurseId;
            PatientId = patientId;
        }
    }
}
