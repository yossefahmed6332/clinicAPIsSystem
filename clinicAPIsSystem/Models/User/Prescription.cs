using clinicAPIsSystem.Models.User.MedicalStaff;

namespace clinicAPIsSystem.Models.User
{
    public class Prescription
    {
        public int Id { get; set; } 
        public string Diagnosis { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!; 
        public 

    }
}
