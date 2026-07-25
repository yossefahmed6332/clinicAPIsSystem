using clinicAPIsSystem.Models.User.MedicalStaff;
namespace clinicAPIsSystem.Models
{
    public class Qualification
    {
        public int Id { get; set;  }
        public string Degree { get; set; } = null!;
        public string University { get; set; } = null!;
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();


    }
}
