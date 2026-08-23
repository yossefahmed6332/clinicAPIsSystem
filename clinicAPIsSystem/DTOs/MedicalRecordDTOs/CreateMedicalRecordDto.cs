using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.MedicalRecordDTOs
{
    public class CreateMedicalRecordDto
    {
        [Required, Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Height { get; private set; }
        [Required, Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Weight { get; private set; }
        [Required, MaxLength(10)]
        public string BloodType { get; private set; }
        [Required, Range(typeof(int), "1", "2147483647")]
        public int PatientId { get; private set; }

        public CreateMedicalRecordDto(decimal height, decimal weight, string bloodType, int patientId)
        {
            Height = height;
            Weight = weight;
            BloodType = bloodType;
            PatientId = patientId;
        }
    }
}
