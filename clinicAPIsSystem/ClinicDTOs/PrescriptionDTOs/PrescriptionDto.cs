using clinicAPIsSystem.ClinicDTOs.MedicalDTOs;
namespace clinicAPIsSystem.ClinicDTOs.PrescriptionDTOs
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; } = null!;
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!; 
        public string DoctorName { get; set; } = null!;

        public ICollection<MedicalDto> Medicines { get; set; } = new List<MedicalDto>();
    }
}
