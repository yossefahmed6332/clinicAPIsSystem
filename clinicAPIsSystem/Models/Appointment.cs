using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class Appointment
    {
       public int Id { get; set; } 
        public DateTime  StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Patient Patient { get; set; } = null!; 
        public int PatientId { get; set; }
        public Nurse Nurse { get; set; } = null!; 
        public int NurseId {  get; set; }
       
        public Doctor Doctor { get; set; }=null!;
        public int DoctorId { get; set; } 
        public AppointmentStatus Status { get; set; } 


    }
}
