using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
using clinicAPIsSystem.ClinicDTOs.PrescriptionDTOs;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs
{
    public class DoctorDto:MedicalStaffDto
    {
        public string SpecializationName { get; set; } = null!;
        public ICollection<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
    }
}
