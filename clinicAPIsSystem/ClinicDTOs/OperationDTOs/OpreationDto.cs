
using clinicAPIsSystem.ClinicDTOs.AppointmentDTOs;

namespace clinicAPIsSystem.ClinicDTOs.OperationDtos
{
    public class OperationDto
    {
        public int Id { get; set; }
        public int ReceptionistId { get; set; }
        public string ReceptionistName { get; set; } = null!;

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public AppointmentDto Appointment { get; set; } = null!;
        public int AppointmentId { get; set; }

        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
    }
}
