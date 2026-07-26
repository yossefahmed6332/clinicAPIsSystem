using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.MedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class Prescription
    {
        public int Id { get; set; } 
        public string Diagnosis { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!; 
        public int DoctorId { get; set; } 
        public Patient Patient { get; set; } = null!; 
        public int PatientId { get; set; } 
        public ICollection<Medical> Medicals { get; set; } = new HashSet<Medical>(); 

    }
}
