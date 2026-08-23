using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.MedicalRecordDTOs
{
    public class UpdateMedicalRecordDto
    {
        [Required, Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Height { get; private set; }
        [Required, Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Weight { get; private set; }
        [Required, MaxLength(10)]
        public string BloodType { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int PatientId { get; private set; }

        public UpdateMedicalRecordDto(decimal height, decimal weight, string bloodType, int patientId)
        {
            Height = height;
            Weight = weight;
            BloodType = bloodType;
            PatientId = patientId;
        }
    }
}
