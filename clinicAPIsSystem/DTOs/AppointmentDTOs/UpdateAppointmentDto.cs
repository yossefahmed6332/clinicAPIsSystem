using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.AppointmentDTOs
{
    public class UpdateAppointmentDto
    {
        [Required]
        public DateTime StartDate { get; private set; }
        [Required]
        public DateTime EndDate { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int PatientId { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int NurseId { get; private set; }
        [Required, Range(1, int.MaxValue)]
        public int DoctorId { get; private set; }
        [Required, EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus Status { get; private set; }

        public UpdateAppointmentDto(DateTime startDate, DateTime endDate, int patientId, int nurseId, int doctorId, AppointmentStatus status)
        {
            StartDate = startDate;
            EndDate = endDate;
            PatientId = patientId;
            NurseId = nurseId;
            DoctorId = doctorId;
            Status = status;
        }
    }
}
