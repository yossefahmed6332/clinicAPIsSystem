namespace clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff
{
    public class Doctor:MedicalStaff
    {
        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

    }
}
