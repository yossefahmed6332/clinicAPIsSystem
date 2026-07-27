 using System.ComponentModel.DataAnnotations;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.ClinicDTOs.AppointmentDTOs
{
    public class UpdateAppointmentDto
    {
        [Required, Range(0, int.MaxValue)]
        public int DoctorId { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int PatientId { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
        [Required, MaxLength(200)]
        public string Reason { get; set; } = null!;
        [MaxLength(200)]
        public string? Note { get; set; }
        [Required, EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus Status { get; set; }

    }
}
