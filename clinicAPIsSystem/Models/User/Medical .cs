namespace clinicAPIsSystem.Models.User
{
    public class Medical
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string TakeTime { get; set; } = null!; 
        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>(); 
    }
    
}
