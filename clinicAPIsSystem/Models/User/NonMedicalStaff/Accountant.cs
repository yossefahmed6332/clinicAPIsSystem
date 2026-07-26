namespace clinicAPIsSystem.Models.User.NonMedicalStaff
{
    public class Accountant:Employee
    {
        public string LicenseNumber { get; set; } = null!; 
        public int YearsOfExperience { get; set; }
        public ICollection<Operation > Appointments { get; set; } = new HashSet<Operation>(); 

    }
}
