using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.DoctorDTOs
{
    public class DoctorDto:MedicalStaffDto
    {
        public string SpecializationName { get; set; } = null!;
        public ICollection<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
    }
}
