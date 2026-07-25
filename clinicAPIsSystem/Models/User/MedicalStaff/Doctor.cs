namespace clinicAPIsSystem.Models.User.MedicalStaff
{
    public class Doctor:MedicalStaff
    {
        public ICollection <Prescription> Prescriptions { get; set; } = new HashSet<Prescription>(); 
        public Specialization Specialization { get; set; } = null!; 
        public int SpecializationId { get; set; }

    }
}
