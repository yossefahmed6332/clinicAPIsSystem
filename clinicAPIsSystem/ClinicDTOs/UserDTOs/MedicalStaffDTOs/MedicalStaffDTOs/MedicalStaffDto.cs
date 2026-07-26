using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.MedicalStaffDTOs.MedicalStaffDTOs
{
    public class MedicalStaffDto:EmployeeDto
    {
        public int YearsOfExperience { get; set; }
        public string LicenseNumber { get; set; } = null!;
        public Qualification Qualification { get; set; } = null!;
        public int QualificationId { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
