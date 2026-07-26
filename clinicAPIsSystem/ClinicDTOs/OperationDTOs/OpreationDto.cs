
using clinicAPIsSystem.ClinicDTOs.AppointmentDTOs;

namespace clinicAPIsSystem.ClinicDTOs.Operation
{
    public class OpreationDto
    {
        public int Id { get; set; }
        public int AccountantId { get; set; }
        public string AccountantName { get; set; } = null!;

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public AppointmentDto Appointment { get; set; } = null!;
        public int AppointmentId { get; set; }

        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
    }
}
