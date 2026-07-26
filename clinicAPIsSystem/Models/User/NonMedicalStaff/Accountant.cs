namespace clinicAPIsSystem.Models.User.NonMedicalStaff
{
    public class Accountant:Employee
    {
        public string LicenseNumber { get; set; } = null!; 
        public ICollection<Operation > Appointments { get; set; } = new HashSet<Operation>(); 

    }
}
