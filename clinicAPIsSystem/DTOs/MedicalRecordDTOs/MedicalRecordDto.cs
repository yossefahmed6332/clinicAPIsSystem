using clinicAPIsSystem.DTOs.PrescriptionDTOs;
using clinicAPIsSystem.DTOs.VitalSignsDTOs;
using clinicAPIsSystem.DTOs.ExaminationResultDTOs;
namespace clinicAPIsSystem.DTOs.MedicalRecordDTOs
{
    public class MedicalRecordDto
    {
        public int Id { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public int PatientId { get; private set; }
        public ICollection<PrescriptionDto> Prescriptions { get; private set; }
        public ICollection<VitalSignsDto> VitalSigns { get; private set; }
        public ICollection<ExaminationResultDto> ExaminationResults { get; private set; }


        public MedicalRecordDto(int id, double height, double weight, string bloodType, int patientId, ICollection<PrescriptionDto> prescriptions, ICollection<VitalSignsDto> vitalSigns, ICollection<ExaminationResultDto> examinationResults)
        {
            Id = id;
            Height = height;
            Weight = weight;
            BloodType = bloodType;
            PatientId = patientId;
            Prescriptions = prescriptions;
            VitalSigns = vitalSigns;
            ExaminationResults = examinationResults;
        }
    }
}
