namespace clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff
{
    public class Doctor:MedicalStaff
    {
        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();

    }
}
