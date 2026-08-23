using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.VitalSignsDTOs
{
    public class UpdateVitalSignsDto
    {

        [Required, Range(0, 300)]
        public int BloodPressureSystolic { get; private set; }
        [Required, Range(0, 300)]
        public int BloodPressureDiastolic { get; private set; }
        [Required, Range(0, 300)]
        public int HeartRate { get; private set; }
        [Required, Range(0, 45)]
        public decimal Temperature { get; private set; }
        [Required, Range(0, 100)]
        public decimal OxygenSaturation { get; private set; }
        [Required]
        public DateTime RecordedAt { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int NurseId { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int PatientId { get; private set; }

        public UpdateVitalSignsDto(int bloodPressureSystolic, int bloodPressureDiastolic, int heartRate, decimal temperature, decimal oxygenSaturation, DateTime recordedAt, int nurseId, int patientId)
        {
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
