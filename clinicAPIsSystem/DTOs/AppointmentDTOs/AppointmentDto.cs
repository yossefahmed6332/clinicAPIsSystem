
namespace clinicAPIsSystem.DTOs.AppointmentDTOs
{
    public class AppointmentDto
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate {get; private set; }
        public int PatientId { get; private set; }
        public int NurseId { get; private set; }
        public int DoctorId { get; private set; }
        public AppointmentStatus Status { get; private set; } 
        public AppointmentDto(int id, DateTime startDate, DateTime endDate, int patientId, int nurseId, int doctorId)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            PatientId = patientId;
            NurseId = nurseId;
            DoctorId = doctorId;
            Status = AppointmentStatus.pending;
        }
    }
}
