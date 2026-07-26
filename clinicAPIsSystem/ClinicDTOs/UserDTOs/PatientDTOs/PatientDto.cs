using clinicAPIsSystem.ClinicDTOs.UserDTOs.ApplicationUserDTOs;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.PatientDTOs
{
    public class PatientDto:ApplicationUserDto
    {
        public ICollection<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
        public ICollection<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
        public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
    }
}
