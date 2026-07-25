using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.NonMedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class Operation
    {
        public int Id { get; set; } 
        public Accountant Accountant { get; set; } = null!; 
        public int AccountantId { get; set; } 
        public Patient Patient { get; set; } = null!; 
        public int PatientId { get; set; } 
        public Appointment Appointment { get; set; } = null!; 
        public int AppointmentId { get; set; } 
        public decimal Amount { get; set; } 

    }
}
