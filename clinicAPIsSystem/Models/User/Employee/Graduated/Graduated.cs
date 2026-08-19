namespace clinicAPIsSystem.Models.User.Employee.Graduated
{
    public abstract class Graduated:Employee
    {
        public string Degree { get; set; } = null!;
        public string University { get; set; } = null!; 
        public int YearsOfExperience { get; set; }
        public int GraduationYear { get; set; }
        public string License { get; set; }=null!;

    }
}
