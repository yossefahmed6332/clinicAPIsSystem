namespace clinicAPIsSystem.Models.User.NonMedicalStaff
{
    public class Accountant:Employee
    {
        public string LicenseNumber { get; set; } = null!; 
        public ICollection<Appointment > Appointments { get; set; } = new HashSet<Appointment>(); 

    }
}
