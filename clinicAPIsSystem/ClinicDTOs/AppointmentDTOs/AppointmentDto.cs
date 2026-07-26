using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.MedicalStaff;

namespace clinicAPIsSystem.ClinicDTOs.AppointmentDTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; } = null!;
        public int DoctorId { get; set; }
        public string PatientName { get; set; } = null!;
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; } = null!;
        public string? Note { get; set; }
        public AppointmentStatus Status { get; set; }
        public ICollection<OperationDto> Operations { get; set; } = new HashSet<OperationDto>();


    }
}
