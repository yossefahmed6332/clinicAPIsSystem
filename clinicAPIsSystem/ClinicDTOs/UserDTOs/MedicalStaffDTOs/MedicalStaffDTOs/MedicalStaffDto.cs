using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using clinicAPIsSystem.ClinicDTOs.AppointmentDTOs;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs
{
    public class MedicalStaffDto:EmployeeDto
    {
        public int YearsOfExperience { get; set; }
        public string LicenseNumber { get; set; } = null!;
        public string QualificationName { get; set; } = null!;
        public int QualificationId { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; } = new HashSet<AppointmentDto>();
    }
}
