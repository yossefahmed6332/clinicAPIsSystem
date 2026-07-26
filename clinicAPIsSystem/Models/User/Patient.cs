namespace clinicAPIsSystem.Models.User
{
    public class Patient:ApplicationUser
    {
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>(); 
        public ICollection<Operation> Operations { get; set; } = new List<Operation>();

    }
}
