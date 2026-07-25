using clinicAPIsSystem.Models.User.MedicalStaff;
namespace clinicAPIsSystem.Models
{
    public class Specialization
    {
        public int Id { set; get; } 
        public string Name { set; get; } = null!; 
        public string Description { set; get; } = null!; 

        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>(); 

    }
}
