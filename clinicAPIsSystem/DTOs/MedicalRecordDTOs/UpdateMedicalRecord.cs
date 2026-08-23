using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.MedicalRecordDTOs
{
    public class UpdateMedicalRecordDto
    {
        [Required, Range(1, double.MaxValue)]
        public decimal Hieght { get; private set; }
        [Required, Range(0, double.MaxValue)]
        public decimal Weight { get; private set; }
        [Required, MaxLength(10)]
        public string BloodType { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int PatientId { get; private set; }

        public UpdateMedicalRecordDto(decimal hieght, decimal weight, string bloodType, int patientId)
        {
            Hieght = hieght;
            Weight = weight;
            BloodType = bloodType;
            PatientId = patientId;
        }
    }
}
