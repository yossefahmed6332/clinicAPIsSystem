using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.MedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; } 
        public Doctor Doctor { get; set; } = null!; 
        public int DoctorId { get; set; } 
        public Nurse? Nurse { get; set; }
        public int NurseId { get; set; }
        public Patient Patient { get; set; } = null!; 
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; } 
        public string Reason { get; set; } = null!; 
        public string ?Note { get; set; } 
        public AppointmentStatus Status { get; set; } 
        public ICollection<Operation> Operations { get; set; } = new HashSet<Operation>();


    }
}
