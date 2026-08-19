namespace clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff
{
    public abstract class MedicalStaff:Graduated
    {
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

    }
}
