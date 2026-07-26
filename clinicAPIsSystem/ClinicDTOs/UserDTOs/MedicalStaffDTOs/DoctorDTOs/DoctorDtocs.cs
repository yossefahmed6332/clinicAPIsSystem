using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs
{
    public class DoctorDtocs:MedicalStaffDto
    {
        public SpecializationDto Specialization { get; set; } = null!;
        public ICollection<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
    }
}
